using Infrastructure.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Motion
{
    public class ShipMovePresenter: MonoBehaviour
    {
        private IPlayerMover _playerMover;
        private AreaControl _areaControl;

        public void SetMoveState(InputAction.CallbackContext context) => 
            _playerMover.CheckPhase(context);

        private void Start()
        {
            _playerMover = AllServices.Container.Single<IPlayerMover>();
            _areaControl = new AreaControl();
            SetStartSettings();
        }
        
        private void FixedUpdate()
        {
            _areaControl.CheckPositionInArea(gameObject);
            _playerMover.UpdatePosition(transform);
        }

        private void SetStartSettings() => 
            _playerMover.SetActualState(MoveStates.Inertia);
    }
}