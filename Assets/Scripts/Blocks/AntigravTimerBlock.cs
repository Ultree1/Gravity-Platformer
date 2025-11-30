using UnityEngine;
using System.Collections;

public class AntigravTimerBlock : MonoBehaviour
{
	private Rigidbody2D rb;
	private BlockBehaviour blockBehaviour;

	[SerializeField] private float resetTimer = 0.5f;
	private bool isHit = false;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		blockBehaviour = GetComponent<BlockBehaviour>();
		rb.mass = 10;
		rb.gravityScale = 0;
	}

	public void BlockHit(int bulletNum)
	{
		if (!isHit) {
			isHit = true;
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
	}

	private IEnumerator ResetGrav()
	{
		yield return new WaitForSeconds(resetTimer);
		blockBehaviour.gravity = Vector2.zero;
		yield return new WaitForSeconds(0.1f);
		rb.linearVelocity = Vector2.zero;
		isHit = false;
		yield return null;
	}
}
