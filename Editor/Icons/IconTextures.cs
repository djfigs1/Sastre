using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using File = UnityEngine.Windows.File;

namespace Sastre.Editor.Icons
{
    public class IconTextures
    {
        public const string PackageName = "com.djfigs1.sastre";
        public const string IconImageDirectory = "Packages/" + PackageName + "/Editor/Icons/Images";

        private static readonly Dictionary<string, Texture2D> _textureCache = new();
        
        public static Texture2D GetIconTexture(string name)
        {
            if (_textureCache.TryGetValue(name, out var cachedTex))
            {
                return cachedTex;
            }

            var imgPath = $"{IconImageDirectory}/{name}.png";
            if (!File.Exists(imgPath))
            {
                return null;
            }

            var loadedTex = (Texture2D)AssetDatabase.LoadAssetAtPath(imgPath, typeof(Texture2D));
            _textureCache[name] = loadedTex;
            
            return loadedTex;
        }
    }
}