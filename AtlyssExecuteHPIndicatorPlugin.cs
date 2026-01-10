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
        public const string MODVERSION = "1.0.1";

        private readonly List<Image> trackedBars = new List<Image>();
        private int scanCounter;

        private void FixedUpdate()
        {
            // Procura novas barras ocasionalmente
            //if (Time.frameCount % 30 == 0) // a cada ~0.5s
            //    ScanForHealthBars();

            scanCounter++;

            if (scanCounter >= 30)
            {
                scanCounter = 0;
                ScanForHealthBars();
            }

            // Atualiza somente as barras conhecidas
            for (int i = trackedBars.Count - 1; i >= 0; i--)
            {
                var img = trackedBars[i];

                if (img == null)
                {
                    trackedBars.RemoveAt(i);
                    continue;
                }

                float percent = img.fillAmount;
                var graphic = img.GetComponent<Graphic>();

                if (graphic == null)
                    continue;

                graphic.color = percent <= 0.249f
                    ? new Color(1f, 0.9f, 0.1f)
                    : Color.green;
            }
        }

        private void ScanForHealthBars()
        {
            foreach (var img in GameObject.FindObjectsOfType<Image>())
            {
                if (img.name == "_fill_healthbar" && !trackedBars.Contains(img))
                {
                    trackedBars.Add(img);
                }
            }
        }
    }
}
