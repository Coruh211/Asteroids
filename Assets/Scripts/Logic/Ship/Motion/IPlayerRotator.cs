using Infrastructure.Services;
using UnityEngine;

namespace Logic.Ship.Motion
{
    public interface IPlayerRotator: IService
    {
        public Vector3 RotateLeft(float speed);
        public Vector3 RotateRight(float speed);
        public void ReadKeyKodeEvent(string name);
        public void SetActualState(RotateStates state);
        public RotateStates GetActualState();
        
        public void UpdateRotateWithState(Transform obj, float speed);
    }
}