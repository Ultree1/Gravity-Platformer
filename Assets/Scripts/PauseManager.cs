using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public static bool gameIsPaused = false;

    private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!gameIsPaused)
			{
				Pause();
			}
            else
			{
				Resume();
			}
		}
	}

    public void Pause()
	{
		pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        Object.FindFirstObjectByType<GunAim>().GetComponent<GunAim>().enabled = false;
        Object.FindFirstObjectByType<PlayerMovementScript>().GetComponent<PlayerMovementScript>().enabled = false;
	}

    public void Resume()
	{
		pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        Object.FindFirstObjectByType<GunAim>().GetComponent<GunAim>().enabled = true;
        Object.FindFirstObjectByType<PlayerMovementScript>().GetComponent<PlayerMovementScript>().enabled = true;
	}
}
