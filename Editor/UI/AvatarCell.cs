using UnityEngine;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class AvatarCell : VisualElement
    {
        private const float CellBorderRadius = 8f;
        
        public AvatarCell()
        {
            style.justifyContent = Justify.Center;
            style.alignItems = Align.Center;
            style.flexDirection = FlexDirection.Column;
            
            var preview = new Image
            {
                style =
                {
                    width = 100,
                    height = 100,
                    marginBottom = 8f,
                    backgroundColor = SastreTheme.BackgroundColor
                }
            };

            preview.style.borderTopLeftRadius = preview.style.borderTopRightRadius =
                preview.style.borderBottomLeftRadius = preview.style.borderBottomRightRadius = CellBorderRadius;

            var label = new Label("Avatar Name");
            label.style.unityTextAlign = TextAnchor.MiddleCenter;
            
            Add(preview);
            Add(label);
        }
        
    }
}