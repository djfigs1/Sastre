using System.Collections.Generic;
using System.Linq;
using Sastre.Editor.Utility;
using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEditor.Search;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class SearchView : VisualElement
    {
        private readonly ISearchProvider _searchProvider;
        private string _searchQuery;
        private readonly VisualElement _grid;
        
        public SearchView(ISearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
            _grid = new GridLayout();
            
            var scrollView = new ScrollView(ScrollViewMode.Vertical);
            scrollView.Add(_grid);
            
            var toolbarView = new ToolbarView(scrollView);
            var searchField = new ToolbarSearchField();
            searchField.RegisterValueChangedCallback(evt =>
            {
                PerformSearch(evt.newValue);
            });
            toolbarView.Toolbar.AddRightItem(searchField);
            
            this.FlexGrow(1);
            
            PerformSearch(string.Empty);
            Add(toolbarView);
        }

        private async void PerformSearch(string query)
        {
            var children = _grid.Children().ToArray();
            foreach (var child in children)
            {
                _grid.Remove(child);
            }
            
            var items = await _searchProvider.Search(query);

            foreach (var item in items)
            {
                CreateItemCell(item);
            }
        }
        
        private void CreateItemCell(ISearchResult result)
        {
            var paddingCell = new VisualElement()
                .Margin(16);

            var avatarCell = new SearchItemCell(result.Name, result.Preview);
            avatarCell.RegisterCallback<PointerUpEvent>(evt =>
            {
                result.Open();
            });
            
            paddingCell.Add(avatarCell);
            _grid.Add(paddingCell);
        }
    }
}