using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    private string newGameLevel = "GravTestLevel";

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    public void NewGame()
    {
        LoadLevel(newGameLevel);
    }

    private void LoadLevel() {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

    public void Restart()
	{
		LoadLevel();
	}

    public void NewLevel(string nextLevel)
    {
        LoadLevel(nextLevel);
    }

    public void GameOver()
    {
        PlayerPrefs.SetString("PreviousLevelName", SceneManager.GetActiveScene().name);
        LoadLevel("GameOver");
    }
}
