using Sastre.Editor.Utility;
using Tactile.UI.UIToolkitExtensions.Extensions;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class AvatarMenu : VisualElement
    {
        public AvatarMenu()
        {
            this.FlexGrow(1);
            
            Add(new SearchView(new AssetSearchProvider("t:Prefab t:VRCAvatarDescriptor")));
        }
    }
}