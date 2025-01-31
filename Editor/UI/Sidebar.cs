using UnityEngine.UIElements;
using UnityEngine;

namespace Sastre.Editor.UI
{
    public class Sidebar : VisualElement
    {
        public readonly ActionBar HeaderActionBar;
        public readonly VisualElement Content;
        public readonly ActionBar FooterActionBar;
        
        public Sidebar()
        {
            style.backgroundColor = SastreTheme.BackgroundColor;
            style.minWidth = 250f;
            style.paddingLeft = 8f;
            style.paddingRight = 8f;
            style.paddingBottom = 8f;
            style.paddingTop = 8f;
            HeaderActionBar = new ActionBar();
            Content = new VisualElement
            {
                style =
                {
                    flexGrow = 1f
                }
            };
            FooterActionBar = new ActionBar();
            
            Add(HeaderActionBar);
            Add(Content);
            Add(FooterActionBar);
        }
    }
}