using UnityEngine;

namespace Sastre.Editor.Utility
{
    public interface ISearchResult
    {
        public string Name { get; }
        public Texture Preview { get; }

        void Open();
    }
}