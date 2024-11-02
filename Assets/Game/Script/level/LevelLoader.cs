using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Level
{
    public sealed class LevelLoader : MonoBehaviour
    {
        private LevelLoader() { }
        public static void LoadLevel(string levelName)
        {
            SceneManager.LoadSceneAsync(levelName);
        }

        public static void LoadLevel(int index)
        {
            SceneManager.LoadSceneAsync(index);

        }

        public static void ReloadLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(currentScene.buildIndex);

        }

        public static void QuitGame()
        {
            Application.Quit();
        }

    }
}




