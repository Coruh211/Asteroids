using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider assets;
        public GameFactory(IAssetProvider assetProvider)
        {
            assets = assetProvider;
        }
        public GameObject CreateObject(string path)
        {
            return assets.Instantiate(path);
        }
        
       
    }
}