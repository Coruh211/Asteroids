using UniRx;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class LaserSpawnController : ILaserSpawner
    {
        private readonly WeaponFactory _weaponFactory;
        private readonly int _maxLasers;
        private readonly float _laserKd;
        
        private int _lasersCount;
        private float _laserTimer;
        private bool _kd;

        public LaserSpawnController(WeaponFactory weaponFactory, float laserKd, int lasersCount)
        {
            _laserKd = laserKd;
            _lasersCount = lasersCount;
            _maxLasers = lasersCount;
            _weaponFactory = weaponFactory;
        }

        public float GetLasersCount() =>
            _lasersCount;

        public float GetLaserTimer() =>
            _laserTimer;

        public void TrySpawnLaser(GameObject obj, GameObject parent, GameObject spawnPoint)
        {
            if(_lasersCount <= 0)
                return;
            
            if(!_kd)
                StartLaserKD();
            
            _weaponFactory.CreateWeapon(obj, parent, spawnPoint);
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