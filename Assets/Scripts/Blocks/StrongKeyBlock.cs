using UnityEngine;

public class StrongKeyBlock : MonoBehaviour
{
	[SerializeField] private GameObject keySpawner;
	private BlockBehaviour.BlockType heavy = BlockBehaviour.BlockType.Heavy;
	private BlockBehaviour.BlockType strongKey = BlockBehaviour.BlockType.StrongKey;
	private BlockBehaviour.BlockType key = BlockBehaviour.BlockType.Key;
	private BlockBehaviour.BlockType lockB = BlockBehaviour.BlockType.Lock;
	public Transform SpawnerPosition;

	private Rigidbody2D rb;
	private BlockBehaviour blockBehaviour;
	private float velocity;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		blockBehaviour = GetComponent<BlockBehaviour>();
		rb.gravityScale = 0;
		rb.mass = 100;
		blockBehaviour.gravity = Vector2.down;
	}

	private void Update()
	{
		velocity = rb.linearVelocity.magnitude;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Block"))
		{
			BlockBehaviour collisionBlock = collision.gameObject.GetComponent<BlockBehaviour>();
			BlockBehaviour.BlockType colBlock = collisionBlock.blockType;
			if (colBlock != heavy && colBlock != strongKey && colBlock != lockB && velocity >= 10)
			{
				// Play destruction animation

				// Play block break sound

				// Spawn key (if needed)
				if (collisionBlock.blockType == key)
				{
					Transform spawnPosition = collision.gameObject.GetComponent<KeyBlock>().SpawnerPosition;
					Instantiate(keySpawner, spawnPosition.position, Quaternion.identity);
				}

				// Destroy collided block
				rb.linearVelocity = Vector2.zero;
				Destroy(collision.gameObject, 0.1f);
			}
			else
			{
				rb.linearVelocity = Vector2.zero;
			}
		}
	}

	public void BlockHit(int bulletNum)
	{
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
