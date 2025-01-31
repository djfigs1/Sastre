using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class ActionBar : VisualElement
    {
        public ActionBar()
        {
            style.paddingBottom = 8f;
            style.paddingTop = 8f;
            style.paddingLeft = 8f;
            style.paddingRight = 8f;
            style.alignItems = Align.Stretch;
            style.justifyContent = Justify.FlexEnd;
            style.minHeight = 36f;
            style.flexDirection = FlexDirection.Row;
        }

        public void AddRightItem(VisualElement actionElement)
        {
            Add(actionElement);
        }
    }
}