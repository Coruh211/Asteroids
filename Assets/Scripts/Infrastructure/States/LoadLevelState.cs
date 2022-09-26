using System;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using LoadScreen;
using Logic.Ship;
using Logic.UI.UICanvas;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState: IPayloadedState<string>
    {
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
            gameFactory.CreateObject(AssetPath.GlobalInput);
            GameObject player = gameFactory.CreateObject(AssetPath.PlayerPath);
            GameObject ui = gameFactory.CreateObject(AssetPath.UICanvasPath);
            ui.GetComponent<InformationTextsPresenter>().Init(player, AllServices.Container.Single<IPlayerMover>(), AllServices.Container.Single<IPlayerRotator>());

            stateMachine.Enter<GameLoopState>();
        }
    }
}