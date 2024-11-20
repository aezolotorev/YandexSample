using Cysharp.Threading.Tasks;

public class GameBootstraper : IGameBootstraper
{
    private const string sceneName = "MainMenu";

    private ISceneLoader _sceneLoader;

    public GameBootstraper(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;

        LoadServices().Forget();
    }

    public async UniTaskVoid LoadServices()
    {
        await _sceneLoader.LoadSceneAsync(sceneName);
    }
}
