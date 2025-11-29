using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    
    public void PlayGame()
	{
        Debug.Log("Game Start.");
		SceneManager.LoadScene("GravTestLevel");
	}

    public void QuitGame()
	{
		Application.Quit();
        Debug.Log("Game Quit.");
	}
}
