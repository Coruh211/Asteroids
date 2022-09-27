using Infrastructure.AssetManagement;
using Services.Input;
using StaticData;
using UnityEngine;

namespace Logic.Ship.Motion
{
    public class PlayerRotator: IPlayerRotator
    {
        private float _rotateSpeed;
        private readonly ShipSO _shipSo;
        private RotateStates _actualRotateState;

        public PlayerRotator(ShipSO shipSo)
        {
            _shipSo = shipSo;
            SetParameters();
        }

        public void ReadKeyKodeEvent(string name)
        {
            _actualRotateState = name switch
            {
                InputConstants.Left => RotateStates.Left,
                InputConstants.Right => RotateStates.Right,
                _ => RotateStates.Stop
            };
        }
        
        public void UpdateRotateWithState(Transform obj)
        {
            switch (_actualRotateState)
            {
                case RotateStates.Left:
                    obj.transform.Rotate(RotateLeft());
                    break;
                case RotateStates.Right:
                    obj.transform.Rotate(RotateRight());
                    break;
                case RotateStates.Stop:
                    break;
            }
        }
        
        public void SetActualState(RotateStates state) => 
            _actualRotateState = state;

        public RotateStates GetActualState() =>
            _actualRotateState;

        private Vector3 RotateLeft() => 
            new(0, 0, _rotateSpeed);

        private Vector3 RotateRight() => 
            new(0, 0, -_rotateSpeed);
        
        private void SetParameters() =>
            _rotateSpeed = _shipSo.rotateSpeed;
    }
}