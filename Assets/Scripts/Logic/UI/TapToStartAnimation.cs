using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Logic.UI
{
    public class TapToStartAnimation: MonoBehaviour
    {
        [SerializeField] private float intervalTime;
        [SerializeField] private float alphaForInterval;
        [SerializeField] private float maxAlpha;
        [SerializeField] private float minAlpha;
        
        private TextMeshProUGUI _text;
        private IDisposable _intervalDispose;
        
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            DownAlpha();
        }

        private void DownAlpha()
        {
            _intervalDispose = Observable.Interval(intervalTime.sec()).TakeUntilDisable(gameObject)
                .Subscribe(x =>
                {
                    if (_text.alpha < minAlpha)
                    {
                        _intervalDispose.Dispose();
                        UpAlpha();
                    }
                    
                    _text.alpha -= alphaForInterval;
                });
        }

        private void UpAlpha()
        {
            _intervalDispose = Observable.Interval(intervalTime.sec()).TakeUntilDisable(gameObject)
                .Subscribe(x =>
                {
                    if (_text.alpha >= maxAlpha)
                    {
                        _intervalDispose.Dispose();
                        DownAlpha();
                    }
                    
                    _text.alpha += alphaForInterval;
                });
        }
    }
}