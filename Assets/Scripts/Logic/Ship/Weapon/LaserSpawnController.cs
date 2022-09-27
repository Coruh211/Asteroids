using Infrastructure.AssetManagement;
using StaticData;
using UniRx;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class LaserSpawnController : ILaserSpawner
    {
        private readonly WeaponFactory _weaponFactory;
        private GameObject _laserPrefab;
        private LaserSO _laserSo;
        
        private int _lasersCount;
        private int _maxLasers;
        
        private float _laserKd;
        private float _laserTimer;
        
        private bool _kd;
        
        public LaserSpawnController(WeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
            GetSoInformation();
        }

        private void GetSoInformation()
        {
            _laserSo = AssetContainer.LaserSo;
            _laserKd = _laserSo.laserKd;
            _lasersCount = _laserSo.lasersCount;
            _maxLasers = _lasersCount;
            _laserPrefab = _laserSo.laserPrefab;
        }

        public float GetLasersCount() =>
            _lasersCount;

        public float GetLaserTimer() =>
            _laserTimer;

        public void TrySpawnLaser(GameObject parent, GameObject spawnPoint)
        {
            if(_lasersCount <= 0)
                return;
            
            if(!_kd)
                StartLaserKD();
            
            _weaponFactory.CreateWeapon(_laserPrefab, parent, spawnPoint);
        }

        private void StartLaserKD()
        {
            _kd = true;
            _laserTimer = _laserKd;
            
            Observable.Interval(1f.sec()).Subscribe(x =>
            {
                CheckCondition();
                _laserTimer--;
            });
        }

        private void CheckCondition()
        {
            if (_laserTimer != 0) 
                return;
                
            _lasersCount++;
            
            if (_lasersCount < _maxLasers)
            {
                StartLaserKD();
            }
            else
            {
                _kd = false;
            }
        }
    }
}