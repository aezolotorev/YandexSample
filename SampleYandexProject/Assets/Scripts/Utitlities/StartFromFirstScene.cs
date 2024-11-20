using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
[InitializeOnLoad]
public class StartFromFirstScene : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadFirstScene()
    {       
      SceneManager.LoadScene(0);
    }
}
#endif
/*
  public int record = 0;
        public int seed = 0;
        public int score = 0;
        public int soundValue = 1;
        public int musicValue = 1;
        public bool isEducationFinish = false;
        public int life = 3;
        public int currIndex = 0;*/