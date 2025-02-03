using Sastre.Editor.Utility;
using UnityEngine.UIElements;

namespace Sastre.Editor.UI
{
    public class ItemsMenu : VisualElement
    {
        public ItemsMenu()
        {
            Add(new SearchView(new AssetSearchProvider("p: t:Prefab t:VrcfUpgradeableMonoBehaviour")));
        }
    }
}