using System;
using Infrastructure;
using Logic.Ship;
using TMPro;
using UnityEngine;

namespace Logic.UI.UICanvas
{
    public class InformationTextsPresenter: MonoBehaviour
    {
        [SerializeField] private GameObject information;
        [SerializeField] private TextMeshProUGUI positionTxt;
        [SerializeField] private TextMeshProUGUI angleTxt;
        [SerializeField] private TextMeshProUGUI speedTxt;
        [SerializeField] private TextMeshProUGUI laserChargesTxt;
        [SerializeField] private TextMeshProUGUI laserChargeKDTxt;
        
        private GameObject _player;
        private IPlayerMover _playerMover;
        private IPlayerRotator _playerRotator;
        private Vector2 _limitZ = new Vector3(-180, 180);

        public void Init(GameObject player, IPlayerMover playerMover, IPlayerRotator playerRotator)
        {
            _player = player;
            _playerMover = playerMover;
            _playerRotator = playerRotator;
        }
        
        private void Start()
        {
            information.SetActive(false);
            EventManager.OnStartGame.Subscribe(ShowInfo);
        }

        private void FixedUpdate()
        {
            SetPositionText();
            SetAngle();
            SetSpeed();
        }

        private void SetSpeed() => 
            speedTxt.text = "Speed: " + _playerMover.GetMomentumSpeed();

        private void SetAngle()
        {
            float angleZ = _player.transform.eulerAngles.z;
            
            while (angleZ > 180f)
                angleZ -= 360f;
            while (angleZ < -180f)
                angleZ += 360f;
            
            angleTxt.text = "Angle: " + (int)angleZ;
        }

        private void SetPositionText() => 
            positionTxt.text = "Pos: " + _player.transform.position;

        private void ShowInfo() => 
            information.SetActive(true);
    }
}