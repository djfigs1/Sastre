using System.Collections.Generic;
using Sastre.Editor.Icons;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class SastreInterface : VisualElement
    {
        private readonly SastrePage[] Pages = {
            new("Avatars", "account", new AvatarMenu()),
            new("Items", "baseball-bat", new ItemsMenu())
        };

        private ItemRow[] _rows;
        private PageController<int> _pageController;
        
        public SastreInterface()
        {
            _rows = new ItemRow[Pages.Length];
            style.flexDirection = FlexDirection.Row;
            style.flexGrow = 1f;

            _pageController = new PageController<int>(0);
            var sidebarView = new SidebarView(_pageController);
            
            for (var i = 0; i < Pages.Length; i++)
            {
                var page = Pages[i];
                var row = _rows[i] = new ItemRow
                {
                    Text = page.Name,
                    IsSelected = i == 0,
                    Icon = page.Icon
                };

                var pageIndex = i;
                row.RegisterCallback<PointerUpEvent>(_ => { SetPage(pageIndex); });

                sidebarView.Sidebar.Content.Add(row);
                _pageController.AddPage(i, page.Element);
            }

            Add(sidebarView);
        }

        private void SetPage(int index)
        {
            var lastRow = _rows[_pageController.CurrentPage];
            lastRow.IsSelected = false;

            var newRow = _rows[index];
            newRow.IsSelected = true;
            _pageController.SetPage(index);
        }

        private class SastrePage
        {
            public readonly string Name;
            public readonly Texture Icon;
            public readonly VisualElement Element;

            public SastrePage(string name, string iconName, VisualElement element)
            {
                Name = name;
                Icon = IconTextures.GetIconTexture(iconName);
                Element = element;
            }
        }
    }
}