using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI.UICanvas
{
    public class ButtonsHolder: MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button restartButton;
        
        private void Start()
        {
            restartButton.onClick.AddListener(RestartGame);
            startButton.onClick.AddListener(StartGame);
        }

        private void RestartGame()
        {
            EventManager.OnRestartGame.Invoke();
        }

        private void StartGame()
        {
            EventManager.OnStartGame.Invoke();
        }
    }
}