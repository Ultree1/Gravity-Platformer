using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D body;
    private Transform t;
    private SpriteRenderer playerSprite;
    public GameObject fireball;
    [Header("Movement")]
    float horizontalMovement;
    public float playerWalkAcceleration = 7f;
    public float playerRunAcceleration = 10f;
    private float playerAcceleration = 0f;
    public float playerMaxSpeed = 10.0f;
    public float playerDeceleration = 4f;
    private int playerDirection = 1;
    [Header("Jumping")]
    public float jumpPower = 10f;
    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;
    [Header("Crouching / Size")]
    public bool isBig = false;
    public Vector2 smallSize;
    public Vector2 smallCrouchSize;
    public Vector2 largeSize;
    public Vector2 largeCrouchSize;
    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;
    [Header("Powerups / UI")]
    public static int coins = 0;
    public static float timer = 0;
    public bool hasFlower = false;
    private void Awake()
    {
        t = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAcceleration = playerWalkAcceleration;
        smallSize = new Vector2(1f, 1f);
        smallCrouchSize = new Vector2(1f, 0.8f);
        largeSize = new Vector2(1f, 2f);
        largeCrouchSize = new Vector2(1f, 1.5f);
        if (isBig)
        {
            t.localScale = largeSize;
        }
        else
        {
            t.localScale = smallSize;
        }
        

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Checks if the player's groundCheck box is overlapping with a rigidbody with the groundLayer included
    bool IsGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        //if the player is inputting left or right, accelerate the player in that direction
        if (horizontalMovement != 0)
        {
            body.AddForce(new Vector2(horizontalMovement * playerAcceleration, 0f));
        }
        //otherwise, if they aren't moving left or right, AddForce in opposition to their current velocity.x
        //and stop them completely if their velocity is under a certain threshold (to prevent jiggling)
        else
        {

            if (Mathf.Abs(body.linearVelocity.x) < 0.1f)
            {
                body.linearVelocity = new Vector2(0f, body.linearVelocity.y);
            }
            else
            {
                body.AddForce(new Vector2(playerDeceleration * -Mathf.Sign(body.linearVelocity.x), 0f));
            }
        }
        //limit the player's horizontal velocity to playerMaxSpeed
        body.linearVelocity = new Vector2(Mathf.Sign(body.linearVelocity.x) * Mathf.Min(playerMaxSpeed, Mathf.Abs(body.linearVelocity.x)), body.linearVelocity.y);
        Gravity();
    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print(isBig);
            
            if (isBig == true)
            {
                t.localScale = largeCrouchSize;
            }
            else
            {
                t.localScale = smallCrouchSize;
            }
        }
        else if (context.canceled)
        {
            print(isBig);
            if (isBig == true)
            {
                t.localScale = largeSize;
            }
            else
            {
                t.localScale = smallSize;
            }
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("Sprinting");
            playerAcceleration = playerRunAcceleration;

            if (hasFlower)
            {
                print("projectile shot!");
                ShootFire();
            }
        }
        else if (context.canceled)
        {
            print("Walking");
            playerAcceleration = playerWalkAcceleration;
        }
    }

    private void ShootFire()
    {
        Vector2 pos = new Vector2(t.position.x+playerDirection, t.position.y);
        Instantiate(fireball, pos, Quaternion.identity);
    }

    private void Gravity()
    {
        if (body.linearVelocity.y < 0)
        {
            body.gravityScale = baseGravity * fallSpeedMultiplier;
            body.linearVelocity = new Vector2(body.linearVelocity.x, Mathf.Max(body.linearVelocity.y, -maxFallSpeed));
        }
        else
        {
            body.gravityScale = baseGravity;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {

            if (context.performed)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * 0.5f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            isBig = true;
            t.localScale = largeSize;
        }
        else if (collision.gameObject.CompareTag("Flower"))
        {
            hasFlower = true;
            isBig = true;
            t.localScale = largeSize;
            playerSprite.color = Color.red;
        }
    }
}
