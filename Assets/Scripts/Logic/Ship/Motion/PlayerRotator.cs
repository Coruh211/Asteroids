using Services.Input;
using UnityEngine;

namespace Logic.Ship.Motion
{
    public class PlayerRotator: IPlayerRotator
    {
        private RotateStates _actualRotateState;
        
        public void ReadKeyKodeEvent(string name)
        {
            switch (name)
            {
                case InputConstants.Left:
                    _actualRotateState = RotateStates.Left;
                    break;
                case InputConstants.Right:
                    _actualRotateState = RotateStates.Right;
                    break;
                default:
                    _actualRotateState = RotateStates.Stop;
                    break;
            }
        }
        
        public void UpdateRotateWithState(Transform obj, float speed)
        {
            switch (_actualRotateState)
            {
                case RotateStates.Left:
                    obj.transform.Rotate(RotateLeft(speed));
                    break;
                case RotateStates.Right:
                    obj.transform.Rotate(RotateRight(speed));
                    break;
                case RotateStates.Stop:
                    break;
            }
        }
        
        public Vector3 RotateLeft(float speed) => 
            new(0, 0, speed);

        public Vector3 RotateRight(float speed) => 
            new(0, 0, -speed);


        public void SetActualState(RotateStates state) => 
            _actualRotateState = state;

        public RotateStates GetActualState() =>
            _actualRotateState;

        
    }
}