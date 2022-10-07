using Infrastructure;
using StaticData;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Motion
{
    public class PlayerRotator: IPlayerRotator
    {
        private float _rotateSpeed;
        private readonly ShipSO _shipSo;
        private float direction;

        public PlayerRotator(ShipSO shipSo)
        {
            _shipSo = shipSo;
            SetParameters();
        }

        public void CheckCondition(InputAction.CallbackContext context)
        {
            if(!GeneralInputState.Instance.input)
                return;
            
            direction = context.ReadValue<float>();
        }
        
        public void UpdateRotate(Transform obj) => 
            obj.transform.Rotate(Rotate());
        

        private Vector3 Rotate() => 
            new(0, 0, -_rotateSpeed * direction);
        
        private void SetParameters() =>
            _rotateSpeed = _shipSo.rotateSpeed;
    }
}