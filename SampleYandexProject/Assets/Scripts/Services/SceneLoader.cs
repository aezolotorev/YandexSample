using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class SceneLoader : ISceneLoader
{
    //TODO: добавить остальные сцены
    private const string MainSceneKey = "MainMenu";
    private const string LevelSceneKey = "Level";

    public async UniTask LoadSceneAsync(string sceneName)
    {
        await Addressables.LoadSceneAsync(sceneName);
    }

    public async UniTask LoadLevelSceneAsync()
    {
        await Addressables.LoadSceneAsync(MainSceneKey);
    }

    public async UniTask LoadMainSceneAsync()
    {
        await Addressables.LoadSceneAsync(LevelSceneKey);
    }
}
