using Sastre.Editor.Icons;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class SastreInterface : VisualElement
    {
        public SastreInterface()
        {
            style.flexDirection = FlexDirection.Row;
            style.flexGrow = 1f;

            var sidebarView = new SidebarView(new AvatarMenu());

            var rowNames = new[] { ("Avatars", "account"), ("Armatures", "human"), ("Clothing", "tshirt"), ("Items", "baseball-bat") };
            for (var index = 0; index < rowNames.Length; index++)
            {
                var rowName = rowNames[index];
                var row = new ItemRow
                {
                    Text = rowName.Item1,
                    IsSelected = index == 0,
                    Icon = IconTextures.GetIconTexture(rowName.Item2)
                };
                sidebarView.Sidebar.Content.Add(row);
            }

            Add(sidebarView);
        }
    }
}