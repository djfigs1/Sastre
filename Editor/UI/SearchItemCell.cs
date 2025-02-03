using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class SearchItemCell : VisualElement
    {
        private const float CellBorderRadius = 8f;

        public SearchItemCell(string name, Texture preview)
        {
            this.JustifyContent(Justify.Center)
                .AlignItems(Align.Center)
                .FlexDirection(FlexDirection.Column)
                .Width(150);

            var previewImage = new Image()
                .Width(100)
                .Height(100)
                .MarginBottom(8)
                .BackgroundColor(SastreTheme.BackgroundColor)
                .BorderRadius(CellBorderRadius)
                .Overflow(Overflow.Hidden)
                .Image(preview);

            var label = new Label(name)
                .UnityTextAlign(TextAnchor.MiddleCenter);

            Add(previewImage);
            Add(label);
        }
    }
}