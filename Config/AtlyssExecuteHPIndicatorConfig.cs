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
                "Execute HP threshold (0.0 – 1.0)",
                0.299f,
                "Enemies can be executed when their HP is at or below this percentage"
            );

            NormalLowHPColor = config.Bind(
                "Colors",
                "NormalLowHP",
                "#e3852d",
                "Color of normal enemies when HP is low"
            );

            NormalHighHPColor = config.Bind(
                "Colors",
                "NormalHighHP",
                "#5de882",
                "Color of normal enemies when HP is high"
            );

            EliteColor = config.Bind(
                "Colors",
                "Elite",
                "#5704d4",
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
                "#090017",
                "Background color for elite enemies"
            );
        }
    }
}
