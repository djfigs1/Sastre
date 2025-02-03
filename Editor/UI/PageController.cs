using System;
using System.Collections.Generic;
using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class PageController<T> : VisualElement
    {
        private readonly Dictionary<T, IPageProvider> _pages = new();
        private VisualElement _currentPageElement;
        private T _currentPage;

        public T CurrentPage
        {
            get => _currentPage;
            set => SetPage(value);
        }

        public PageController(T initialPage)
        {
            this.FlexGrow(1);
            
            _currentPage = initialPage;
        }
        
        public void AddPage(T key, VisualElement element)
        {
            AddPage(key, new Page(element));
        }
        
        public void AddPage(T key, Func<VisualElement> page)
        {
            AddPage(key, new PageFactory(page));
        }

        private void AddPage(T key, IPageProvider provider)
        {
            _pages[key] = provider;
            
            if (_currentPageElement == null && key.Equals(_currentPage))
            {
                SetPage(_currentPage);
            }   
        }

        public void SetPage(T key)
        {
            if (_currentPageElement != null)
            {
                Remove(_currentPageElement);
            }

            _currentPage = key;
            _currentPageElement = _pages[key].GetPage();
            Add(_currentPageElement);
        }

        private interface IPageProvider
        {
            public VisualElement GetPage();
        }

        private class PageFactory : IPageProvider
        {
            private readonly Func<VisualElement> _elementFactory;

            public PageFactory(Func<VisualElement> elementFactory)
            {
                _elementFactory = elementFactory;
            }

            public VisualElement GetPage() => _elementFactory.Invoke();
        }


        private class Page : IPageProvider
        {
            private readonly VisualElement _element;
            
            public Page(VisualElement element)
            {
                _element = element;
            }

            public VisualElement GetPage() => _element;
        }
    }
}