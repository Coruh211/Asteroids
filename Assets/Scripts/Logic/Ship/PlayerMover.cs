
using System;
using Services.Input;
using UnityEngine;

namespace Logic.Ship
{
    public class PlayerMover : IPlayerMover
    {
        private MoveStates _actualMoveState;
        private float _actualSpeed;
        private bool _firstAppeal;
        private float _maxSpeed;


        public float maxSpeed { private get; set; }

        public void ReadKeyKodeEvent(string name)
        {
            if (InputConstants.Up == name)
            {
                _actualMoveState = MoveStates.Up;
            }
        }
        
        public void UpdatePositionWithState(Transform obj, float speed)
        {
            switch (_actualMoveState)
            {
                case MoveStates.Up:
                    obj.transform.Translate(Move(speed));
                    break;
                case MoveStates.Inertia:
                    obj.Translate(SimulationInertia(speed));
                    break;
            }
        }
        
        public Vector3 SimulationInertia(float speed)
        {
            if (_actualSpeed <= 0)
            {
                _actualSpeed = 0;
                return Vector3.zero;
            }

            _actualSpeed -= speed;

            return new Vector3(0, _actualSpeed, 0);
        }

        public Vector3 Move(float speed)
        {
            if(_actualSpeed < maxSpeed)
                _actualSpeed += speed;
            
            return new Vector3(0, _actualSpeed, 0);
        }

        public void SetActualState(MoveStates state) => 
            _actualMoveState = state;

        public MoveStates GetActualState() => 
            _actualMoveState;

        public float GetMomentumSpeed() =>
            _actualSpeed;

        
    }
}