using System;
using Services.Input;
using UnityEngine;

namespace Logic.General
{
    public class GeneralInputSystem : Singleton<GeneralInputSystem>
    {
        [SerializeField] private KeyCode upKeyCode = KeyCode.W;
        [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
        [SerializeField] private KeyCode rightKeyCode = KeyCode.D;
        [SerializeField] private KeyCode fireKeyCode = KeyCode.Space;
        [SerializeField] private KeyCode laserKeyCode = KeyCode.R;

        private bool _enableInput;
        public event Action<string> KeyDown;
        public event Action MoveKeyUp;
        public event Action AngleKeyUp;

        
        private void Start() => 
            EventManager.OnStartGame.Subscribe(EnableInput);
        
        private void Update()
        {
            if(!_enableInput)
                return;

            CheckMoveInput();
            CheckAngleInput();
            CheckFireInput();
        }
        
        private void CheckFireInput()
        {
            if(Input.GetKey(fireKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Bullet);
            }
            else if (Input.GetKeyDown(laserKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Laser);   
            }
        }

        private void CheckAngleInput()
        {
            if (Input.GetKey(leftKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Left);
            }
            else if (Input.GetKey(rightKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Right);
            }
            else if (Input.GetKeyUp(leftKeyCode))
            {
                AngleKeyUp?.Invoke();
            }
            else if (Input.GetKeyUp(rightKeyCode))
            {
                AngleKeyUp?.Invoke();
            }
        }

        private void CheckMoveInput()
        {
            if (Input.GetKey(upKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Up);
            }
            else if (Input.GetKeyUp(upKeyCode))
            {
                MoveKeyUp?.Invoke();
            }
        }


        private void EnableInput() => 
            _enableInput = true;
    }
}