using Infrastructure.AssetManagement;
using Infrastructure.Services;
using Logic.Ship.Weapon;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Weapon
{
    public class BulletPresenter: MonoBehaviour
    {
        [SerializeField] private GameObject bulletSpawnPoint;
        
        
        private WeaponFactory _weaponFactory;
        private BulletSpawnController _bulletSpawnController;
        
        public void FireKey(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _bulletSpawnController.TrySpawnBullet(gameObject, bulletSpawnPoint);
            }
        }
        
        private void Start()
        {
            _bulletSpawnController = new BulletSpawnController(AllServices.Container.Single<IWeaponFactory>());
        }
    }
}