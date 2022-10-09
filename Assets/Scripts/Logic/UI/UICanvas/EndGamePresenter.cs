using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Logic.UI.UICanvas
{
    public class EndGamePresenter : MonoBehaviour
    {
        [SerializeField] private GameObject endGameObject;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI topScoreText;
        
        private IScoreController _scoreController;

        private void Start()
        {
            endGameObject.SetActive(false);
            _scoreController = AllServices.Container.Single<IScoreController>();
            EventManager.OnEndGame.Subscribe(ShowEndGame);
            EventManager.OnRestartGame.Subscribe(HideMenu);
        }

        private void ShowEndGame()
        {
            endGameObject.SetActive(true);
            scoreText.text = "Score: " + _scoreController.GetScore();
            topScoreText.text = "TopScore: " + _scoreController.GetTopScore();
        }

        private void HideMenu()
        {
            endGameObject.SetActive(false);
        }
    }
}