using Sastre.Editor.Icons;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class IconButton : Button
    {
        public IconButton(string iconName)
        {
            style.width = 25;
            style.height = 25;
            style.backgroundImage = new StyleBackground(IconTextures.GetIconTexture(iconName));
            style.unityBackgroundImageTintColor = SastreTheme.AccentColor;
            style.backgroundColor = Color.clear;
            style.borderBottomColor = Color.clear;
            style.borderTopColor = Color.clear;
            style.borderLeftColor = Color.clear;
            style.borderRightColor = Color.clear;
        }
    }
}