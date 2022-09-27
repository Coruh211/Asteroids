using Infrastructure.Services;
using Logic.General;
using UnityEngine;

namespace Logic.Ship.Motion
{
    public class ShipMovePresenter: MonoBehaviour
    {
        private IPlayerMover _playerMover;
        private AreaControl _areaControl;

        private void Start()
        {
            _playerMover = AllServices.Container.Single<IPlayerMover>();
            _areaControl = new AreaControl();
            
            GeneralInputSystem.Instance.MoveKeyDown += SetMoveState;
            GeneralInputSystem.Instance.MoveKeyUp += StartInertia;
            
            SetStartSettings();
        }

        private void FixedUpdate()
        {
            _areaControl.CheckPositionInArea(gameObject);
            _playerMover.UpdatePositionWithState(transform);
        }

        private void SetStartSettings() => 
            _playerMover.SetActualState(MoveStates.Inertia);
        
        private void StartInertia() => 
            _playerMover.SetActualState(MoveStates.Inertia);

        private void SetMoveState(string keyName) => 
            _playerMover.ReadKeyKodeEvent(keyName);
    }
}