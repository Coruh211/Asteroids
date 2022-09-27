using Infrastructure.Services;
using UnityEngine;

namespace Logic.Ship.Motion
{
    public interface IPlayerMover: IService
    {
        public void ReadKeyKodeEvent(string name);
        public void SetActualState(MoveStates state);
        public MoveStates GetActualState();
        public float GetMomentumSpeed();

        public void UpdatePositionWithState(Transform obj);

    }
}