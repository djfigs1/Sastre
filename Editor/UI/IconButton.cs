using Sastre.Editor.Icons;
using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class IconButton : Button
    {
        public IconButton(string iconName)
        {
            this.Width(25)
                .Height(25)
                .BackgroundImage(new StyleBackground(IconTextures.GetIconTexture(iconName)))
                .UnityBackgroundImageTintColor(SastreTheme.AccentColor)
                .BackgroundColor(Color.clear)
                .BorderColor(Color.clear);
        }
    }
}