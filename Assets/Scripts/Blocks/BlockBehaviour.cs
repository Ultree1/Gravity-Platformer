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
        Key,
        ReverseGravity     // ✅ ADDED
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
                GetComponent<StandardBlock>().BlockHit(bulletNum);
                break;

            case BlockType.Antigrav:
                GetComponent<AntigravBlock>().BlockHit(bulletNum);
                break;

            case BlockType.Timer:
                GetComponent<TimerBlock>().BlockHit(bulletNum);
                break;

            case BlockType.AntigravTimer:
                GetComponent<AntigravTimerBlock>().BlockHit(bulletNum);
                break;

            case BlockType.Heavy:
                GetComponent<HeavyBlock>().BlockHit(bulletNum);
                break;

            case BlockType.Key:
                GetComponent<KeyBlock>().BlockHit(bulletNum);
                break;

            case BlockType.StrongKey:
                GetComponent<StrongKeyBlock>().BlockHit(bulletNum);
                break;

            case BlockType.ReverseGravity:     //NEW BLOCK TYPE
                GetComponent<ReverseGravityBlock>().BlockHit(bulletNum);
                break;
        }
    }
}
