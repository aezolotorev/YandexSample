using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using Zenject;

public class BootstrapSceneInstaller : MonoInstaller<BootstrapSceneInstaller>
{
    

    public override void InstallBindings()
    {
      
        Container.Bind<IGameBootstraper>().To<GameBootstraper>().AsSingle().NonLazy();
    }
}
