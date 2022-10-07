using System;
using DG.Tweening;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class LaserScaler: MonoBehaviour
    {
        [SerializeField] private float laserScaleX;
        [SerializeField] private float timeAnimation;
        
        private float defaultScaleX;

        private void Start()
        {
            defaultScaleX = transform.localScale.x;
            StartLaserAnimation();
        }

        private void StartLaserAnimation()
        {
            transform.DOScaleX(laserScaleX, timeAnimation)
                .OnComplete(() => 
                    transform.DOScaleX(defaultScaleX, timeAnimation)
                        .OnComplete(() => 
                            Destroy(gameObject)));
        }
    }
}