using AtlyssExecuteHPIndicator.Model;
using BepInEx;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AtlyssExecuteHPIndicatorMod
{
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class AtlyssExecuteHPIndicatorPlugin : BaseUnityPlugin
    {
        public const string MODUID = "com.BLKNeko.AtlyssExecuteHPIndicator";
        public const string MODNAME = "com.BLKNeko.Atlyss Execute HP Indicator";
        public const string MODVERSION = "1.1.0";

        //private readonly List<Image> trackedBars = new List<Image>();
        private int scanCounter;
        static readonly Dictionary<Image, TrackedCreep> tracked = new();


        private void FixedUpdate()
        {
            if (++scanCounter >= 30)
            {
                scanCounter = 0;
                ScanForCreeps();
                Cleanup();
            }

            UpdateBars();
        }

        private void ScanForCreeps()
        {
            foreach (var behavior in FindObjectsOfType<CreepBehavior>())
            {
                if (behavior == null)
                    continue;

                var baseCreep = behavior._baseCreep;
                if (baseCreep == null)
                    continue;

                var gui = baseCreep.GetComponent<StatusEntityGUI>();
                if (gui == null)
                    continue;

                var fg = StatusEntityGUIAccess.GetHealthBarFill(gui);
                var bg = GetHealthBarBackground(gui);

                if (fg == null || bg == null)
                    continue;

                tracked[fg] = new TrackedCreep
                {
                    Behavior = behavior,
                    Foreground = fg,
                    Background = bg
                };
            }
        }

        void UpdateBars()
        {
            foreach (var kv in tracked)
            {
                var creep = kv.Value;

                if (creep.Behavior == null ||
                    creep.Foreground == null ||
                    creep.Background == null)
                    continue;

                bool isElite = creep.Behavior._scriptCreep._isElite;
                float percent = creep.Foreground.fillAmount;

                if (!isElite)
                {
                    creep.Foreground.color = percent <= 0.299f
                        ? Color.yellow
                        : Color.green;

                    creep.Background.color = new Color(0f, 0f, 0f, 0.6f); // fundo escuro
                }
                else
                {
                    creep.Foreground.color = Color.cyan;
                    creep.Background.color = new Color(0f, 0.4f, 0.4f, 0.8f); // fundo elite
                }
            }
        }


        Image GetHealthBarBackground(StatusEntityGUI gui)
        {
            var barObj = StatusEntityGUIAccess.GetHealthBarObject(gui);
            if (barObj == null)
                return null;

            var t = barObj.transform.Find("_healthbarFill");
            if (t == null)
                return null;

            return t.GetComponent<Image>();
        }

        void Cleanup()
        {
            var toRemove = new List<Image>();

            foreach (var kv in tracked)
            {
                if (kv.Key == null ||
                    kv.Value.Behavior == null ||
                    !kv.Value.Behavior.gameObject)
                {
                    toRemove.Add(kv.Key);
                }
            }

            foreach (var img in toRemove)
                tracked.Remove(img);
        }



    }
}
