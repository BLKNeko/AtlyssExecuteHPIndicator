using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AtlyssExecuteHPIndicator.Utils
{
    static class ColorUtils
    {
        public static Color Parse(string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out var color))
                return color;

            return Color.white;
        }
    }

}
