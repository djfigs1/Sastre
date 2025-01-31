using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class AvatarMenu : VisualElement
    {
        public AvatarMenu()
        {
            style.flexGrow = 1f;
            
            var group = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                    flexWrap = Wrap.Wrap,
                    justifyContent = Justify.SpaceBetween,
                }
            };

            var toolbarView = new ToolbarView(group);
            toolbarView.Toolbar.AddRightItem(new IconButton("plus"));
            toolbarView.Toolbar.AddRightItem(new ToolbarSearchField());
            for (var i = 0; i < 25; i++)
            {
                var paddingCell = new VisualElement
                {
                    style =
                    {
                        marginLeft = 16f,
                        marginRight = 16f,
                        marginTop = 16f,
                        marginBottom = 16f
                    }
                };
                var avatarCell = new AvatarCell();
                paddingCell.Add(avatarCell);
                group.Add(paddingCell);
            }

            Add(toolbarView);
        }
    }
}