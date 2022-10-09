using Infrastructure;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Weapon
{
    public class LaserPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject laserSpawnPoint;
        
        public ILaserSpawner _laserSpawnController;
        
        public void LazerKey(InputAction.CallbackContext context)
        {
            if(!GeneralInputState.Instance.input)
                return;
            
            if(context.phase == InputActionPhase.Started)
                _laserSpawnController.TrySpawnLaser(gameObject, laserSpawnPoint);
        }
        
        private void Awake()
        {
            _laserSpawnController = AllServices.Container.Single<ILaserSpawner>();
        }
    }
}