using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI.UICanvas
{
    public class ButtonsHolder: MonoBehaviour
    {
        [SerializeField] private Button startButton;
        
        private void Start()
        {
            startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            EventManager.OnStartGame.Invoke();
            startButton.gameObject.SetActive(false);
        }
    }
}