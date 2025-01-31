using UnityEditor;
using UnityEngine;

namespace Sastre.Editor.UI
{
    public class SastreWindow : EditorWindow
    {
        [MenuItem("Window/Sastre")]
        public static void ShowAvatarMenu()
        {
            var window = GetWindow<SastreWindow>();
            window.titleContent = new GUIContent("Sastre");
        }
    
        public void CreateGUI()
        {
            rootVisualElement.Add(new SastreInterface());
        }
    }
}
