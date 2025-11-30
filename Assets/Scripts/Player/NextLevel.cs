using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerBehaviour playerBehaviour;
    private PlayerMovementScript playerMovement;
    private PlayerBehaviour.WalkDirection moveDirection;
    private float moveSpeed;
    private string nextLevel;

    private void OnEnable()
	{
        rb = GetComponent<Rigidbody2D>();
        playerBehaviour = GetComponent<PlayerBehaviour>();
        playerMovement = GetComponent<PlayerMovementScript>();
		moveDirection = playerBehaviour.nextLevelDirection;
        nextLevel = playerBehaviour.nextLevel;

        StartCoroutine(MoveNextLevel(moveDirection));
	}

    private IEnumerator MoveNextLevel(PlayerBehaviour.WalkDirection moveDirection)
	{
        Vector3 direction;
        moveSpeed = playerMovement.moveSpeed;

        float elapsed = 0f;
        float duration = 1f;

		if (moveDirection == PlayerBehaviour.WalkDirection.left)
		{
			direction = Vector3.left;
		}
        else
		{
			direction = Vector3.right;
		}

        while (elapsed < duration)
		{
			rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);
            elapsed += Time.deltaTime;
            yield return null;
		}

        GameManager.Instance.WinLevel(nextLevel);
	}
}
