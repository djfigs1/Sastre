using UnityEngine;
using UnityEngine.UIElements;

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
            style.flexDirection = FlexDirection.Row;
            style.alignItems = Align.Center;
            _image = new Image
            {
                style =
                {
                    width = 25,
                    height = 25,
                    marginRight = 4,
                },
                tintColor = SastreTheme.AccentColor
            };
            
            _label = new Label
            {
                style =
                {
                    fontSize = 14,
                    color = Color.white
                }
            };
            
            Add(_image);
            Add(_label);

            style.paddingBottom = 8f;
            style.paddingTop = 8f;
            style.paddingLeft = 8f;
            style.paddingRight = 8f;
            style.borderBottomLeftRadius = 8f;
            style.borderTopLeftRadius = 8f;
            style.borderTopRightRadius = 8f;
            style.borderBottomRightRadius = 8f;
        }
    }
}