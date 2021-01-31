using UnityEngine;
using UnityEngine.SceneManagement; // namespace containing functionality for scene management

public class SceneLoader : MonoBehaviour {

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void LoadStartScene() {
        FindObjectOfType<GameManager>().ResetGameStatus();
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
