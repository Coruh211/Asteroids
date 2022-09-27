using Infrastructure.Services;
using UnityEngine;

namespace Logic.Ship.Motion
{
    public interface IPlayerRotator: IService
    {
        public void ReadKeyKodeEvent(string name);
        public void SetActualState(RotateStates state);
        public RotateStates GetActualState();
        
        public void UpdateRotateWithState(Transform obj);
    }
}