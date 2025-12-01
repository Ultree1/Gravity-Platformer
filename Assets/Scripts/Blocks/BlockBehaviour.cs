using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

	private float gravityForce = 9.81f;
    public Vector2 gravity;

	private bool Antigrav = false;

    public enum BlockType
    {
	Standard,
	Antigrav,
	Timer,
	AntigravTimer,
	Heavy,
	StrongKey,
	Key
    }
    public BlockType blockType;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		if (blockType == BlockType.Antigrav || blockType == BlockType.AntigravTimer)
		{
			Antigrav = true;
		}
	}

    private void FixedUpdate()
	{
		if (!Antigrav)
		{
			rb.AddForce(gravity * gravityForce * rb.mass, ForceMode2D.Force);
		}
		else
		{
			rb.linearVelocity = gravity * (gravityForce/2);
		}
	}

	private void OnCollisionStay2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.CompareTag("Player"))
		{
			PlayerMovementScript playerMovement = collisionInfo.gameObject.GetComponent<PlayerMovementScript>();
			if (collisionInfo.transform.DotTest(transform, Vector2.down))
			{
				playerMovement.blockSpeed = rb.linearVelocity.x;
				playerMovement.onBlock = true;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerMovementScript playerMovement = collision.gameObject.GetComponent<PlayerMovementScript>();
			playerMovement.onBlock = false;
			playerMovement.blockSpeed = 0;
		}
	}

	public void Hit(int bulletNum)
	{
		switch (blockType)
		{

		case BlockType.Standard:
			StandardBlock sBlock = GetComponent<StandardBlock>();
			sBlock.BlockHit(bulletNum);
			break;

		case BlockType.Antigrav:
			AntigravBlock aBlock = GetComponent<AntigravBlock>();
			aBlock.BlockHit(bulletNum);
			break;

		case BlockType.Timer:
			TimerBlock tBlock = GetComponent<TimerBlock>();
			tBlock.BlockHit(bulletNum);
			break;

		case BlockType.AntigravTimer:
			AntigravTimerBlock atBlock = GetComponent<AntigravTimerBlock>();
			atBlock.BlockHit(bulletNum);
			break;

		case BlockType.Heavy:
			HeavyBlock hBlock = GetComponent<HeavyBlock>();
			hBlock.BlockHit(bulletNum);
			break;

		case BlockType.Key:
			KeyBlock kBlock = GetComponent<KeyBlock>();
			kBlock.BlockHit(bulletNum);
			break;

		case BlockType.StrongKey:
			StrongKeyBlock skBlock = GetComponent<StrongKeyBlock>();
			skBlock.BlockHit(bulletNum);
			break;
		}

		

	}
}
