using Infrastructure;
using StaticData;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Motion
{
    public class PlayerMover : IPlayerMover
    {
        private MoveStates _actualMoveState;
        private float _actualSpeed;
        private bool _firstAppeal;
        private float _maxSpeed;
        private readonly ShipSO _shipSo;
        private float _speed;
        private IPlayerMover _playerMoverImplementation;

        public PlayerMover(ShipSO shipSo)
        {
            _shipSo = shipSo;
            SetParameters();
        }
        
        private void SetParameters()
        {
            _speed = _shipSo.moveSpeed;
            _maxSpeed = _shipSo.maxMoveSpeed;
        }

        public void CheckPhase(InputAction.CallbackContext callbackContext)
        {
            if(!GeneralInputState.Instance.input)
                return;
            
            switch (callbackContext.phase)
            {
                    case InputActionPhase.Started:
                        _actualMoveState = MoveStates.Up;
                        break;
                    case InputActionPhase.Canceled:
                        _actualMoveState = MoveStates.Inertia;
                        break;
            }
        }

        public void UpdatePosition(Transform obj)
        {
            switch (_actualMoveState)
            {
                case MoveStates.Up:
                    obj.transform.Translate(Move());
                    break;
                case MoveStates.Inertia:
                    obj.Translate(SimulationInertia());
                    break;
            }
        }

        public void RestartPosition(Transform obj)
        {
            obj.position = Vector3.zero;
            obj.rotation = Quaternion.identity;
        }

        public void SetActualState(MoveStates state) => 
            _actualMoveState = state;

        public MoveStates GetActualState() => 
            _actualMoveState;

        public float GetMomentumSpeed() =>
            _actualSpeed;
        
        private Vector3 SimulationInertia()
        {
            if (_actualSpeed <= 0)
            {
                _actualSpeed = 0;
                return Vector3.zero;
            }

            _actualSpeed -= _speed;

            return new Vector3(0, _actualSpeed, 0);
        }

        private Vector3 Move()
        {
            if(_actualSpeed < _maxSpeed)
                _actualSpeed += _speed;
            
            return new Vector3(0, _actualSpeed, 0);
        }
    }
}