using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    public float gravityForce = 9.81f / 3;
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

    private void Update()
    {
        if (!Antigrav)
        {
            rb.AddForce(gravity * gravityForce * rb.mass, ForceMode2D.Force);
        }
        else
        {
            rb.linearVelocity = gravity * gravityForce;
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
