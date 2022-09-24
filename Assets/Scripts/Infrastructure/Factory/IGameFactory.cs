using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory: IService
    {
        GameObject CreatePlayer(GameObject initialPoint);
        void CreateHUD();
    }
}