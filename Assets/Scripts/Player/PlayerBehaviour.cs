using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public enum WalkDirection
	{
		left,
        right
	}
    [HideInInspector] public WalkDirection nextLevelDirection = WalkDirection.left;
    [HideInInspector] public string nextLevel;

    public void MoveTransition()
	{
		GetComponent<NextLevel>().enabled = true;
	}
}

