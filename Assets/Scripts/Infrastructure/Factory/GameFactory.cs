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
        public GameObject CreatePlayer(GameObject initialPoint)
        {
            return assets.Instantiate(AssetPath.PlayerPath, initialPoint.transform.position);
        }
        
        public void CreateHUD()
        {
            assets.Instantiate(AssetPath.HUDPath);
        }
    }
}