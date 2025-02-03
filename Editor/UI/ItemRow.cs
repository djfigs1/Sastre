using UnityEngine;
using UnityEngine.UIElements;
using Tactile.UI.UIToolkitExtensions.Extensions;

namespace Sastre.Editor.UI
{
    public class ItemRow : VisualElement
    {
        public Texture Icon
        {
            get => _image.image;
            set => _image.image = value;
        }

        public string Text
        {
            get => _label.text;
            set => _label.text = value;
        }

        public bool IsSelected
        {
            set => style.backgroundColor = new Color(1f, 1f, 1f, value ? 0.15f : 0);
        }

        private readonly Image _image;
        private readonly Label _label;

        public ItemRow()
        {
            this.FlexDirection(FlexDirection.Row)
                .AlignItems(Align.Center)
                .Padding(8)
                .BorderRadius(8);
            
            _image = new Image()
                .Width(25)
                .Height(25)
                .MarginRight(4)
                .TintColor(SastreTheme.AccentColor);

            _label = new Label()
                .FontSize(14)
                .Color(Color.white);

            Add(_image);
            Add(_label);
        }
    }
}