using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using Logic;
using Logic.Ship.Motion;
using StaticData;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState: IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }
        
        public void Exit()
        {
            //throw new NotImplementedException();
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>("Game");

        private void RegisterServices()
        {
            AssetContainer.LoadResources();
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IScoreController>( new ScoreController());
        }
    }
}