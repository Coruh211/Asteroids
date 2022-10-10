using System.Diagnostics;
using Infrastructure.Factory;
using Infrastructure.Services;
using LoadScreen;
using Logic.Enemy;
using Logic.Ship.Motion;
using Logic.Ship.Weapon;
using Logic.Spawner;
using Logic.UI.UICanvas;
using StaticData;
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
        private SpawnController _spawnController;
        private GameObject[] spawnPoints;
        private GameObject spawnContainer;


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
            _allServices.RegisterSingle<IWeaponFactory>(new WeaponFactory());
            _allServices.RegisterSingle<ILaserSpawner>(new LaserSpawnController(_allServices.Single<IWeaponFactory>()));
        }

        private void OnLoaded()
        {
            _gameFactory.CreateObject(AssetPath.ObjectsPoolPath);
            _gameFactory.CreateObject(AssetContainer.ShipSo.shipPrefab);
            
            GameObject ui = _gameFactory.CreateObject(AssetPath.UICanvasPath);
            
            spawnPoints = GameObject.FindGameObjectsWithTag(TagsContainer.Spawner);
            
            _spawnController = new SpawnController(spawnPoints);
            ui.GetComponent<InformationTextsPresenter>().Init( AllServices.Container.Single<IPlayerMover>());

            _stateMachine.Enter<GameLoopState>();
        }
    }
}