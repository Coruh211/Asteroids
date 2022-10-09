using UnityEngine;

namespace Logic.UI.UICanvas
{
    public class StartGamePresenter: MonoBehaviour
    {
        [SerializeField] private GameObject startGame;

        private void Start()
        {
            EventManager.OnStartGame.Subscribe(HideMenu);
            EventManager.OnRestartGame.Subscribe(ShowMenu);
        }

        private void ShowMenu() => 
            startGame.SetActive(true);

        private void HideMenu() => 
            startGame.SetActive(false);
    }
}