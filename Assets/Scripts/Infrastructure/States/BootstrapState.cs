using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using Logic.Ship;
using Logic.Ship.Motion;
using Services.Input;

namespace Infrastructure.States
{
    public class BootstrapState: IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine stateMachine;
        private SceneLoader sceneLoader;
        private AllServices services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            stateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }
        
        public void Exit()
        {
            //throw new NotImplementedException();
        }

        private void EnterLoadLevel() => 
            stateMachine.Enter<LoadLevelState, string>("Game");

        private void RegisterServices()
        {
            services.RegisterSingle<IAssetProvider>(new AssetProvider());
            services.RegisterSingle<IGameFactory>(new GameFactory(services.Single<IAssetProvider>()));
            services.RegisterSingle<IPlayerRotator>(new PlayerRotator());
            services.RegisterSingle<IPlayerMover>(new PlayerMover());
        }

        
    }
}