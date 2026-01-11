using BepInEx.Configuration;

namespace AtlyssExecuteHPIndicator.Config
{
    internal static class AtlyssExecuteHPIndicatorConfig
    {
        internal static ConfigEntry<float> ExecuteHPPercent;

        internal static ConfigEntry<string> NormalLowHPColor;
        internal static ConfigEntry<string> NormalHighHPColor;
        internal static ConfigEntry<string> EliteColor;
        internal static ConfigEntry<string> BackgroundNormalColor;
        internal static ConfigEntry<string> BackgroundEliteColor;

        internal static void Init(ConfigFile config)
        {
            ExecuteHPPercent = config.Bind(
                "HP Percent",
                "Execute HP Percent",
                0.299f,
                "HP % needed to Execute"
            );

            NormalLowHPColor = config.Bind(
                "Colors",
                "NormalLowHP",
                "#FFFF00",
                "Color of normal enemies when HP is low"
            );

            NormalHighHPColor = config.Bind(
                "Colors",
                "NormalHighHP",
                "#00FF00",
                "Color of normal enemies when HP is high"
            );

            EliteColor = config.Bind(
                "Colors",
                "Elite",
                "#00FFFF",
                "Color of elite enemies"
            );

            BackgroundNormalColor = config.Bind(
                "Colors",
                "BackgroundNormal",
                "#00000099",
                "Background color for normal enemies"
            );

            BackgroundEliteColor = config.Bind(
                "Colors",
                "BackgroundElite",
                "#004466CC",
                "Background color for elite enemies"
            );
        }
    }
}
