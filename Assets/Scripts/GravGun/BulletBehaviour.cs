using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask objectDestroysBullet;
 
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public enum BulletType
    {
        DownGrav,
        LeftGrav,
        RightGrav,
        UpGrav
    }
    public BulletType bulletType;
    public int bulletNum = 0; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetDestroyTime();

        // set stats based on bullet
        InitializeBulletStats();
        SetVelocity();
    }

    private void InitializeBulletStats()
    {
        if (bulletType == BulletType.RightGrav)
        {
            spriteRenderer.color = Color.red;
            bulletNum = 0;
        }

        else if (bulletType == BulletType.UpGrav)
        {
            spriteRenderer.color = Color.white;
            bulletNum = 1;
        }

        else if (bulletType == BulletType.LeftGrav)
        {
            spriteRenderer.color = Color.blue;
            bulletNum = 2;
        }

        else if (bulletType == BulletType.DownGrav)
        {
            spriteRenderer.color = Color.black;
            bulletNum = 3;
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // is collision within objectDestroysBullet layerMask
        if ((objectDestroysBullet.value & (1 << other.gameObject.layer)) > 0)
        {
            // spawn particles

            // play sound FX

            // destroy bullet
            if (other.gameObject.layer == LayerMask.NameToLayer("Block"))
			{
				BlockBehaviour blockBehaviour = other.gameObject.GetComponent<BlockBehaviour>();
                blockBehaviour.Hit(bulletNum);
			}
            Destroy(gameObject);
        }
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }

    private void SetVelocity()
    {
        rb.linearVelocity = transform.right * normalBulletSpeed;
    }
}
