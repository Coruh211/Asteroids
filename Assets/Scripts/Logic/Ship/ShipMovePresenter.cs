using Infrastructure.Services;
using Services.Input;
using UnityEngine;

namespace Logic.Ship
{
    public class ShipMovePresenter: MonoBehaviour
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;
        
        private IPlayerMover _playerMover;
        private IPlayerRotator _playerRotator;
        

        private void Start()
        {
            _playerMover = AllServices.Container.Single<IPlayerMover>();
            _playerRotator = AllServices.Container.Single<IPlayerRotator>();
            GeneralInputSystem.Instance.KeyDown += SetMoveState;
            GeneralInputSystem.Instance.MoveKeyUp += StartInertia;
            GeneralInputSystem.Instance.AngleKeyUp += StopRotate;
            
            SetStartSettings();
        }

        private void SetStartSettings()
        {
            _playerMover.maxSpeed = maxSpeed;
            _playerMover.SetActualState(MoveStates.Inertia);
            _playerRotator.SetActualState(RotateStates.Stop);
        }

        private void StopRotate() =>
            _playerRotator.SetActualState(RotateStates.Stop); 
        

        private void StartInertia() => 
            _playerMover.SetActualState(MoveStates.Inertia);

        private void SetMoveState(string name)
        {
            _playerMover.ReadKeyKodeEvent(name);
            _playerRotator.ReadKeyKodeEvent(name);
        }
        
        private void FixedUpdate()
        {
            _playerMover.UpdatePositionWithState(transform, speed);
            _playerRotator.UpdateRotateWithState(transform, rotateSpeed);
        }
    }
}