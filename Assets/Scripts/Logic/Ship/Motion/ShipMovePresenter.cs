using Infrastructure;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Motion
{
    public class ShipMovePresenter: MonoBehaviour
    {
        [SerializeField] private GameObject shipSprite;
        
        private IPlayerMover _playerMover;
        private AreaControl _areaControl;

        public void SetMoveState(InputAction.CallbackContext context) => 
            _playerMover.CheckPhase(context);

        private void Start()
        {
            _playerMover = AllServices.Container.Single<IPlayerMover>();
            _areaControl = new AreaControl();
            EventManager.OnRestartGame.Subscribe(RestartPosition);
            SetStartSettings();
        }

        private void RestartPosition()
        {
            shipSprite.SetActive(true);
            _playerMover.RestartPosition(transform);
        }

        private void FixedUpdate()
        {
            if(!GeneralInputState.Instance.input)
                return;
            _areaControl.CheckPositionInArea(gameObject);
            _playerMover.UpdatePosition(transform);
        }

        private void SetStartSettings() => 
            _playerMover.SetActualState(MoveStates.Inertia);
    }
}