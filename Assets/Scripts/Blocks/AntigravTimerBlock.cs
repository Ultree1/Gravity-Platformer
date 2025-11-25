using UnityEngine;
using System.Collections;

public class AntigravTimerBlock : MonoBehaviour
{
	private Rigidbody2D rb;
	private BlockBehaviour blockBehaviour;
	public float resetTimer = 0.5f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		blockBehaviour = GetComponent<BlockBehaviour>();
		rb.gravityScale = 0;
	}

	public void BlockHit(int bulletNum)
	{
		StartCoroutine(ResetGrav());
		if (bulletNum.Equals(0))
		{
			rb.linearVelocity = Vector2.right * blockBehaviour.gravityForce;
		}

        else if (bulletNum.Equals(1))
		{
			rb.linearVelocity = Vector2.up * blockBehaviour.gravityForce;
		}

        else if (bulletNum.Equals(2))
		{
			rb.linearVelocity = Vector2.left * blockBehaviour.gravityForce;
		}

        else if (bulletNum.Equals(3))
		{
			rb.linearVelocity = Vector2.down * blockBehaviour.gravityForce;
		}
	}

	private IEnumerator ResetGrav()
	{
		yield return new WaitForSeconds(resetTimer);
		blockBehaviour.gravity = Vector2.zero;
		yield return new WaitForSeconds(0.1f);
		rb.linearVelocity = Vector2.zero;
		yield return null;
	}
}
