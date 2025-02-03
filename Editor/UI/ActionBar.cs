using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class ActionBar : VisualElement
    {
        public ActionBar()
        {
            this.Padding(8)
                .AlignItems(Align.Stretch)
                .JustifyContent(Justify.FlexEnd)
                .MinHeight(36)
                .FlexDirection(FlexDirection.Row);
        }

        public void AddRightItem(VisualElement actionElement)
        {
            Add(actionElement);
        }
    }
}