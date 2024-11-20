using UnityEngine;
using Zenject;
using YG;

public class ProjectContextInstaller : MonoInstaller<ProjectContextInstaller>
{
    [SerializeField] private YandexGame yandexGamePrefab;
    public override void InstallBindings()
    {        
        Container.Bind<IAssetService>().To<AssetService>().AsSingle();
        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        Container.Bind<YandexGame>().FromComponentInNewPrefab(yandexGamePrefab).AsSingle().NonLazy(); ;
        Container.Bind<YandexGameProvider>().AsSingle().NonLazy();
    }
}
