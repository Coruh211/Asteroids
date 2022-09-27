using Logic.General;
using Services.Input;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class FirePresenter: MonoBehaviour
    {
        [SerializeField] private GameObject weaponSpawnPoint;
        
        private WeaponFactory _weaponFactory;
        private BulletSpawnController _bulletSpawnController;
        private LaserSpawnController _laserSpawnController;


        private void Start()
        {
            GeneralInputSystem.Instance.FireKeyDown += ReadFireKey;
            _weaponFactory = new WeaponFactory();
            _bulletSpawnController = new BulletSpawnController(_weaponFactory);
            _laserSpawnController = new LaserSpawnController(_weaponFactory);
        }

        private void ReadFireKey(string name)
        {
            switch (name)
            {
                case InputConstants.Bullet:
                    _bulletSpawnController.TrySpawnBullet(gameObject, weaponSpawnPoint);
                    break;
                case InputConstants.Laser:
                    _laserSpawnController.TrySpawnLaser( gameObject, weaponSpawnPoint );
                    break;
            }
        }
    }
}