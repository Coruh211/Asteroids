using Infrastructure.Services;
using UnityEngine;

namespace Logic.Ship
{
    public interface IPlayerMover: IService
    {
        public float maxSpeed { set; }
        public void ReadKeyKodeEvent(string name);
        public Vector3 SimulationInertia(float speed);
        public Vector3 Move(float speed);
        public void SetActualState(MoveStates state);
        public MoveStates GetActualState();
        public float GetMomentumSpeed();

        public void UpdatePositionWithState(Transform obj, float speed);

    }
}