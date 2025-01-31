using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class ToolbarView : VisualElement
    {
        public readonly ActionBar Toolbar;
        public ToolbarView(VisualElement content)
        {
            style.flexGrow = 1f;
            Toolbar = new ActionBar();
            Add(Toolbar);
            Add(content);
        }
    }
}