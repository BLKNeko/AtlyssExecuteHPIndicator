using BepInEx;
using UnityEngine;
using UnityEngine.UI;

namespace AtlyssExecuteHPIndicatorMod
{
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class AtlyssExecuteHPIndicatorPlugin : BaseUnityPlugin
    {
        public const string MODUID = "com.BLKNeko.AtlyssExecuteHPIndicator";
        public const string MODNAME = "com.BLKNeko.Atlyss Execute HP Indicator";
        public const string MODVERSION = "1.0.0";

        private void Update()
        {
            // percorre todas as barras de vida na cena
            foreach (var img in GameObject.FindObjectsOfType<Image>())
            {
                if (img.name == "_fill_healthbar")
                {
                    // porcentagem do HP (0 a 1)
                    float percent = img.fillAmount;
                    //Logger.LogInfo("HP: " + percent);

                    var graphic = img.GetComponent<Graphic>();
                    if (graphic == null)
                        continue;

                    // <= 20% vira amarelo
                    if (percent <= 0.25f)
                        graphic.color = new Color(1f, 0.9f, 0.1f); // amarelo
                    else
                        graphic.color = Color.green;
                }
            }
        }
    }
}
