using System;
using Infrastructure.Services;
using Logic.Enemy;
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

        public void Init( IPlayerMover playerMover)
        {
            _playerMover = playerMover;
            _laserSpawner = AllServices.Container.Single<ILaserSpawner>();
        }

        private void OnEnable()
        {
            _player = GameObject.FindWithTag(TagsContainer.Player);
        }

        private void Start()
        {
            information.SetActive(false);
            EventManager.OnStartGame.Subscribe(ShowInfo);
            EventManager.OnEndGame.Subscribe(HideInfo);
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

        
        private void HideInfo() =>
            information.SetActive(false);
    }
}