using System;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using LoadScreen;
using Logic.Ship;
using Logic.Ship.Motion;
using Logic.UI.UICanvas;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState: IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadCanvas _loadCanvas;
        private readonly IGameFactory _gameFactory;
        private readonly AllServices _allServices;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadCanvas loadCanvas,
            IGameFactory gameFactory, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadCanvas = loadCanvas;
            _gameFactory = gameFactory;
            _allServices = allServices;
        }

        public void Enter(string sceneName)
        {
            _loadCanvas.Show();
            RegisterServices();
            _sceneLoader.Load(sceneName, OnLoaded);
        }
        
        public void Exit()
        {
            _loadCanvas.Hide();    
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<IPlayerRotator>(new PlayerRotator(AssetContainer.ShipSo));
            _allServices.RegisterSingle<IPlayerMover>(new PlayerMover(AssetContainer.ShipSo));
        }

        private void OnLoaded()
        {
            _gameFactory.CreateObject(AssetPath.GlobalInput);
            GameObject player = _gameFactory.CreateObject(AssetContainer.ShipSo.shipPrefab);
            GameObject ui = _gameFactory.CreateObject(AssetPath.UICanvasPath);
            ui.GetComponent<InformationTextsPresenter>().Init(player, AllServices.Container.Single<IPlayerMover>(), AllServices.Container.Single<IPlayerRotator>());

            _stateMachine.Enter<GameLoopState>();
        }
    }
}