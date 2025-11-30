using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("Game Start.");
        GameManager.Instance.NewGame();
    }

    public void QuitGame()
	{
        Debug.Log("Game Quit.");
		Application.Quit();
	}

    public void ResetLevel()
	{
		string previousLevel = PlayerPrefs.GetString("PreviousLevelName");
        if (!string.IsNullOrEmpty(previousLevel))
		{
			GameManager.Instance.NewLevel(previousLevel);
		}
        else
		{
			Debug.Log("No previous level found in PlayerPrefs.");
            NewGame();
		}
	}
}
