using Infrastructure.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Ship.Motion
{
    public interface IPlayerMover: IService
    {
        public void CheckPhase(InputAction.CallbackContext callbackContext);
        public void SetActualState(MoveStates state);
        public MoveStates GetActualState();
        public float GetMomentumSpeed();

        public void UpdatePosition(Transform obj);

        public void RestartPosition(Transform obj);
    }
}