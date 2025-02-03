using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class GridLayout : VisualElement
    {
        public GridLayout()
        {
            this.FlexDirection(FlexDirection.Row)
                .AlignItems(Align.FlexStart)
                .JustifyContent(Justify.FlexStart)
                .FlexWrap(Wrap.Wrap);
        }
    }
}