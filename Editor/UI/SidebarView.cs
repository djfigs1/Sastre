using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class SidebarView : VisualElement
    {
        public readonly Sidebar Sidebar;

        public SidebarView(VisualElement content)
        {
            this.FlexDirection(FlexDirection.Row)
                .FlexGrow(1);
            
            Sidebar = new Sidebar();
            Add(Sidebar);

            var container = new VisualElement()
                .BackgroundColor(SastreTheme.ContentBackground)
                .BorderLeftWidth(1)
                .BorderLeftColor(SastreTheme.BorderColor)
                .FlexGrow(1);
            container.Add(content);
            Add(container);
        }
    }
}