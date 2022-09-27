using Infrastructure.Services;
using Logic.General;
using UnityEngine;

namespace Logic.Ship.Motion
{
    public class ShipRotatePresenter : MonoBehaviour
    {
        private IPlayerRotator _playerRotator;

        private void Start()
        {
            _playerRotator = AllServices.Container.Single<IPlayerRotator>();
            
            GeneralInputSystem.Instance.RotateKeyDown += SetRotateState;
            GeneralInputSystem.Instance.RotateKeyUp += StopRotate;
            
            SetStartSettings();
        }
        
        private void FixedUpdate() => 
            _playerRotator.UpdateRotateWithState(transform);

        private void SetStartSettings() => 
            _playerRotator.SetActualState(RotateStates.Stop);

        private void SetRotateState(string keyName) => 
            _playerRotator.ReadKeyKodeEvent(keyName);
        
        private void StopRotate() =>
            _playerRotator.SetActualState(RotateStates.Stop); 
    }
}