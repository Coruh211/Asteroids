using Infrastructure.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Motion
{
    public class ShipRotatePresenter : MonoBehaviour
    {
        private IPlayerRotator _playerRotator;

        
        public void SetRotateState(InputAction.CallbackContext context) => 
            _playerRotator.CheckCondition(context);
        
        private void Start()
        {
            _playerRotator = AllServices.Container.Single<IPlayerRotator>();
        }
        
        private void FixedUpdate() => 
            _playerRotator.UpdateRotate(transform);

        
        
        
    }
}