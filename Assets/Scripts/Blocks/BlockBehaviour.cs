using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] public float gravityForce = 9.81f/3;
    public Vector2 gravity;

    public enum BlockType
    {
	Standard,
	Antigrav,
	Timer,
	AntigravTimer,
	Heavy,
	StrongKey,
	Key,
	Lock
    }
    public BlockType blockType;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
	{
		rb.AddForce(gravity * gravityForce * rb.mass, ForceMode2D.Force);
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
