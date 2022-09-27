using Infrastructure.AssetManagement;
using StaticData;
using UniRx;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class BulletSpawnController
    {
        private bool _isInterval;
        private readonly float _spawnInterval;
        private readonly WeaponFactory _weaponFactory;
        private readonly BulletSO _bulletSo;
        private readonly GameObject _bulletPrefab;

        public BulletSpawnController(WeaponFactory weaponFactory)
        {
            _bulletSo = AssetContainer.BulletSo;
            _bulletPrefab = _bulletSo.bulletPrefab;
            _spawnInterval = _bulletSo.bulletSpawnInterval;
            _weaponFactory = weaponFactory;
        }
        
        public void TrySpawnBullet( GameObject parent, GameObject weaponSpawnPoint)
        {
            if (_isInterval) 
                return;
            
            StartTimer();
            _weaponFactory.CreateWeapon(_bulletPrefab, parent, weaponSpawnPoint);
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