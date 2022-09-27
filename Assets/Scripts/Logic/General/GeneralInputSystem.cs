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
        
        public event Action<string> FireKeyDown;
        
        public event Action<string> MoveKeyDown;
        public event Action MoveKeyUp;
        
        public event Action<string> RotateKeyDown;
        public event Action RotateKeyUp;
        
        

        
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
                FireKeyDown?.Invoke(InputConstants.Bullet);
            }
            else if (Input.GetKeyDown(laserKeyCode))
            {
                FireKeyDown?.Invoke(InputConstants.Laser);   
            }
        }

        private void CheckAngleInput()
        {
            if (Input.GetKey(leftKeyCode))
            {
                RotateKeyDown?.Invoke(InputConstants.Left);
            }
            else if (Input.GetKey(rightKeyCode))
            {
                RotateKeyDown?.Invoke(InputConstants.Right);
            }
            else if (Input.GetKeyUp(leftKeyCode))
            {
                RotateKeyUp?.Invoke();
            }
            else if (Input.GetKeyUp(rightKeyCode))
            {
                RotateKeyUp?.Invoke();
            }
        }

        private void CheckMoveInput()
        {
            if (Input.GetKey(upKeyCode))
            {
                MoveKeyDown?.Invoke(InputConstants.Up);
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