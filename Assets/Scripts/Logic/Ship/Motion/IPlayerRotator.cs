using Infrastructure.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Motion
{
    public interface IPlayerRotator: IService
    {
        public void CheckCondition(InputAction.CallbackContext name);
        public void UpdateRotate(Transform obj);
    }
}