using UnityEngine;

public class AntigravBlock : MonoBehaviour
{
	private Rigidbody2D rb;
	private BlockBehaviour blockBehaviour;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		blockBehaviour = GetComponent<BlockBehaviour>();
		rb.gravityScale = 0;
	}

	public void BlockHit(int bulletNum)
	{
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
}
