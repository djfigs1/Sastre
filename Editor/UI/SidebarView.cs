using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class SidebarView : VisualElement
    {
        public readonly Sidebar Sidebar;

        public SidebarView(VisualElement content)
        {
            Sidebar = new Sidebar();
            style.flexDirection = FlexDirection.Row;
            Add(Sidebar);
            var container = new VisualElement
            {
                style =
                {
                    backgroundColor = SastreTheme.ContentBackground,
                    borderLeftWidth = 1f,
                    borderLeftColor = SastreTheme.BorderColor
                }
            };
            
            container.Add(content);
            Add(container);
        }
    }
}