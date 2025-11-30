using UnityEngine;
using System.Collections;

public class TimerBlock : MonoBehaviour
{
	private Rigidbody2D rb;
	private BlockBehaviour blockBehaviour;
	public float resetTimer = 0.5f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		blockBehaviour = GetComponent<BlockBehaviour>();
		rb.mass = 10;
		rb.gravityScale = 0;
		blockBehaviour.gravity = Vector2.down;
	}

	public void BlockHit(int bulletNum)
	{
		StartCoroutine(ResetGrav());
		if (bulletNum.Equals(0))
		{
			blockBehaviour.gravity = Vector2.right;
		}

        else if (bulletNum.Equals(1))
		{
			blockBehaviour.gravity = Vector2.up;
		}

        else if (bulletNum.Equals(2))
		{
			blockBehaviour.gravity = Vector2.left;
		}

        else if (bulletNum.Equals(3))
		{
			blockBehaviour.gravity = Vector2.down;
		}
	}

	private IEnumerator ResetGrav()
	{
		yield return new WaitForSeconds(resetTimer);
		blockBehaviour.gravity = Vector2.down;
		yield return null;
	}
}
