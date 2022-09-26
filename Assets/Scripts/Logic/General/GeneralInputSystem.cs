using System;
using UnityEngine;

namespace Services.Input
{
    public class GeneralInputSystem : Singleton<GeneralInputSystem>
    {
        [SerializeField] private KeyCode upKeyCode = KeyCode.W;
        [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
        [SerializeField] private KeyCode rightKeyCode = KeyCode.D;
        [SerializeField] private KeyCode fireKeyCode = KeyCode.Space;
        [SerializeField] private KeyCode laserKeyCode = KeyCode.R;

        private bool enableInput = false;
        public event Action<string> KeyDown;
        public event Action KeyUp;
        public event Action MoveKeyUp;
        public event Action AngleKeyUp;

        
        private void Start() => 
            EventManager.OnStartGame.Subscribe(EnableInput);
        
        private void Update()
        {
            if(!enableInput)
                return;
            
            if (UnityEngine.Input.GetKey(upKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Up);
            }
            else if (UnityEngine.Input.GetKeyUp(upKeyCode))
            {
                MoveKeyUp?.Invoke();
            }
            
            if (UnityEngine.Input.GetKey(leftKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Left);
            }
            else if (UnityEngine.Input.GetKey(rightKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Right);
            }
            else if (UnityEngine.Input.GetKeyUp(leftKeyCode))
            {
                AngleKeyUp?.Invoke();
            }
            else if (UnityEngine.Input.GetKeyUp(rightKeyCode))
            {
                AngleKeyUp?.Invoke();
            }
            
            if(UnityEngine.Input.GetKey(fireKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Fire);
            }
            else if (UnityEngine.Input.GetKey(laserKeyCode))
            {
                KeyDown?.Invoke(InputConstants.Laser);   
            }
        }
        
        private void EnableInput() => 
            enableInput = true;
    }
}