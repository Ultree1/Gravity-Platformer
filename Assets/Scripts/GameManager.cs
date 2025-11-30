using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    [SerializeField] string levelName;

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
        Debug.Log("Game Start.");
        LoadLevel(levelName);
    }

     public void QuitGame()
	{
        Debug.Log("Game Quit.");
		Application.Quit();
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

    public void WinLevel(string levelName)
    {
        LoadLevel(levelName);
    }

    public void ResetLevel()
    {
        LoadLevel("GameOver");
    }

    public void ResetLevel(bool restart)
    {
        if (restart)
		{
			LoadLevel();
		}
        else
		{
			LoadLevel("GameOver");
		}
    }
}
