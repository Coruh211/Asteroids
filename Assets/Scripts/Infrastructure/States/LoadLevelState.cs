using Infrastructure.Factory;
using Infrastructure.Services;
using LoadScreen;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState: IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly LoadCanvas loadCanvas;
        private readonly IGameFactory gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadCanvas loadCanvas, IGameFactory gameFactory)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.loadCanvas = loadCanvas;
            this.gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            loadCanvas.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }
        
        public void Exit()
        {
            loadCanvas.Hide();    
        }

        private void OnLoaded()
        {
            GameObject player = gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));

            gameFactory.CreateHUD();
            
            stateMachine.Enter<GameLoopState>();
        }
    }
}