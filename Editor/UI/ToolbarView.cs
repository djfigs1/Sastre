using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class ToolbarView : VisualElement
    {
        public readonly ActionBar Toolbar;
        public ToolbarView(VisualElement content)
        {
            this.FlexGrow(1);
            
            Toolbar = new ActionBar();
            Add(Toolbar);
            Add(content);
        }
    }
}