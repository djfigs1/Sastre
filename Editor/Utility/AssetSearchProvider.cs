using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Search;
using UnityEngine;

namespace Sastre.Editor.Utility
{
    public class AssetSearchProvider : ISearchProvider
    {
        private readonly string _assetQuery;

        public AssetSearchProvider(string assetQuery)
        {
            _assetQuery = assetQuery;
        }


        public Task<ISearchResult[]> Search(string query)
        {
            var tcs = new TaskCompletionSource<ISearchResult[]>();

            SearchService.Request($"{query} {_assetQuery}",
                (context, result) =>
                {
                    tcs.TrySetResult(result
                        .Select(item => new AssetSearchResult(context, item))
                        .Cast<ISearchResult>()
                        .ToArray());
                });

            return tcs.Task;
        }

        private class AssetSearchResult : ISearchResult
        {
            private readonly SearchContext _context;
            private readonly SearchItem _item;

            public AssetSearchResult(SearchContext context, SearchItem item)
            {
                _context = context;
                _item = item;
            }

            public string Name => _item.GetLabel(_context);
            public Texture Preview => _item.GetPreview(_context, 256 * Vector2.one);
            
            public void Open()
            {
                if (!GlobalObjectId.TryParse(_item.id, out var guid))
                    return;
                
                var path = AssetDatabase.GUIDToAssetPath(guid.assetGUID);
                Debug.Log(path);
                if (path.EndsWith(".prefab"))
                {
                    PrefabStageUtility.OpenPrefab(path);
                }
            }
        }
    }
}