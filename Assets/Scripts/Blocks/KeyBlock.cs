using UnityEngine;

public class KeyBlock : MonoBehaviour
{
	[SerializeField] private GameObject keySpawner;
	public Transform SpawnerPosition;

	private Rigidbody2D rb;
	private BlockBehaviour blockBehaviour;
	private float velocity;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		blockBehaviour = GetComponent<BlockBehaviour>();
		rb.gravityScale = 0;
		blockBehaviour.gravity = Vector2.down;
	}

	private void Update()
	{
		velocity = rb.linearVelocity.magnitude;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (velocity >= 10)
		{
			// Play destruction animation

			// Play block break sound

			// Destroy key block
			Instantiate(keySpawner, SpawnerPosition.position, Quaternion.identity);
			Destroy(gameObject, 0.1f);
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
