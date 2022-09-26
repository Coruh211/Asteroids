using Infrastructure.Services;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public interface ILaserSpawner: IService
    {
        public float GetLasersCount();
        public float GetLaserTimer();
        public void TrySpawnLaser(GameObject obj, GameObject parent, GameObject spawnPoint);
    }
}