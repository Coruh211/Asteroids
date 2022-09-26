using Logic.General;
using Services.Input;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class FirePresenter: MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private GameObject weaponSpawnPoint;
        [SerializeField] private float bulletSpawnInterval;
        [SerializeField] private float laserKd;
        [SerializeField] private int lasersCount;
        
        private WeaponFactory _weaponFactory;
        private BulletSpawnController _bulletSpawnController;
        private LaserSpawnController _laserSpawnController;


        private void Start()
        {
            GeneralInputSystem.Instance.KeyDown += ReadKey;
            _weaponFactory = new WeaponFactory();
            _bulletSpawnController = new BulletSpawnController(_weaponFactory, bulletSpawnInterval);
            _laserSpawnController = new LaserSpawnController(_weaponFactory, laserKd, lasersCount);
        }

        private void ReadKey(string name)
        {
            switch (name)
            {
                case InputConstants.Bullet:
                    _bulletSpawnController.TrySpawnBullet(bulletPrefab, gameObject, weaponSpawnPoint);
                    break;
                case InputConstants.Laser:
                    _laserSpawnController.TrySpawnLaser(laserPrefab, gameObject, weaponSpawnPoint );
                    break;
            }
        }
    }
}