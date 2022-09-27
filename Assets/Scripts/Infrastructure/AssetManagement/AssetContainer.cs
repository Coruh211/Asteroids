using StaticData;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public static class AssetContainer
    {
        public static ShipSO ShipSo;
        public static BulletSO BulletSo;
        public static LaserSO LaserSo;


        public static void LoadResources()
        {
            ShipSo = Resources.Load<ShipSO>(AssetPath.ShipSoPath);
            BulletSo = Resources.Load<BulletSO>(AssetPath.BulletSoPath);
            LaserSo = Resources.Load<LaserSO>(AssetPath.LaserSoPath);
        }
    }
}