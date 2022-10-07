using System;
using Infrastructure;
using Infrastructure.Services;
using Logic.Ship;
using Logic.Ship.Motion;
using Logic.Ship.Weapon;
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
        private ILaserSpawner _laserSpawner;

        public void Init(GameObject player, IPlayerMover playerMover)
        {
            _player = player;
            _playerMover = playerMover;
            _laserSpawner = AllServices.Container.Single<ILaserSpawner>();
        }
        
        private void Start()
        {
            information.SetActive(false);
            EventManager.OnStartGame.Subscribe(ShowInfo);
        }

        private void FixedUpdate()
        {
            if(_player == null)
                return;
            
            SetPositionText();
            SetAngle();
            SetSpeed();
            SetLaserCharges();
            SetLaserChargesKD();
        }

        private void SetLaserChargesKD() => 
            laserChargeKDTxt.text = "New laser charge in: " + _laserSpawner.GetLaserTimer();

        private void SetLaserCharges() => 
            laserChargesTxt.text = "Laser charges: " + _laserSpawner.GetLasersCount();

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