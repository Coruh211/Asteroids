using UniRx;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class BulletSpawnController
    {
        private bool _isInterval;
        private readonly float _spawnInterval;
        private readonly WeaponFactory _weaponFactory;

        public BulletSpawnController(WeaponFactory weaponFactory, float spawnInterval)
        {
            _spawnInterval = spawnInterval;
            _weaponFactory = weaponFactory;
        }
        
        public void TrySpawnBullet(GameObject bulletPrefab, GameObject parent, GameObject weaponSpawnPoint)
        {
            if (_isInterval) 
                return;
            
            StartTimer();
            _weaponFactory.CreateWeapon(bulletPrefab, parent, weaponSpawnPoint);
        }

        private void StartTimer()
        {
            _isInterval = true;
            Observable.Timer(_spawnInterval.sec())
                .Subscribe(x =>
                {
                    _isInterval = false;
                });
        }
    }
}