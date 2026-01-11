using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace AtlyssExecuteHPIndicator.Model
{
    static class StatusEntityGUIAccess
    {
        static readonly FieldInfo healthBarObjectField =
            typeof(StatusEntityGUI).GetField(
                "_healthBarObject",
                BindingFlags.Instance | BindingFlags.NonPublic
            );

        static readonly FieldInfo healthBarFillField =
            typeof(StatusEntityGUI).GetField(
                "_healthBarFill",
                BindingFlags.Instance | BindingFlags.NonPublic
            );

        public static GameObject GetHealthBarObject(StatusEntityGUI gui)
        {
            return healthBarObjectField?.GetValue(gui) as GameObject;
        }

        public static Image GetHealthBarFill(StatusEntityGUI gui)
        {
            return healthBarFillField?.GetValue(gui) as Image;
        }
    }


}
