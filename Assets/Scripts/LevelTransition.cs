using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour.WalkDirection levelDirection;
    [SerializeField] private string levelName;

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
            playerBehaviour.nextLevelDirection = levelDirection;
            playerBehaviour.nextLevel = levelName;
            playerBehaviour.MoveTransition();
		}
	}
}
