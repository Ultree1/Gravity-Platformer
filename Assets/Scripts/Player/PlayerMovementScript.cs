using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    [HideInInspector] public float blockSpeed = 0f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask ground;

    public Vector2 gravityDirection;
    public float moveSpeed = 5f;
    private float currVelX;
    private float currMagX;
    private float move = 0f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;

    private float inputAxis;

    public bool grounded { get; private set; }
    public bool isJumping { get; private set; }
    public bool onBlock = false;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Restart();

        // Detect the correct direction for ground checks
        gravityDirection = PlayerGravity.Instance != null &&
                                PlayerGravity.Instance.IsGravityReversed()
                                ? Vector2.up
                                : Vector2.down;

        grounded = body.Raycast(gravityDirection, ground);

        if (grounded)
        {
            isJumping = PlayerGravity.Instance != null &&
                        PlayerGravity.Instance.IsGravityReversed()
                        ? body.linearVelocity.y < 0f
                        : body.linearVelocity.y > 0f;

            GroundedMovement();
        }

        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        if (inputAxis == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if (inputAxis == -1){
            spriteRenderer.flipX = true;
        }
        currVelX = body.linearVelocity.x;
        currMagX = Mathf.Abs(currVelX);

        if (onBlock)
		{
			move = blockSpeed + (moveSpeed * inputAxis);
		}
        else if(!grounded)
		{
            move = calculateAirMovement(inputAxis, currVelX);
		}
        else
		{
			move = moveSpeed * inputAxis;
		}

        body.linearVelocity = new Vector2(move, body.linearVelocity.y);
	}

    private float calculateAirMovement(float inputAxis, float currVelX)
	{
        float movement = 0f;

		if (inputAxis * currVelX <= 0)
		{
            if (currMagX > moveSpeed)
            {
		        movement = currVelX + (moveSpeed * inputAxis);
            }

            else
			{
				movement = moveSpeed * inputAxis;
			}
	    }

        else
        {
            if (currVelX >= 0)
            {
	            movement = Mathf.Max(currVelX, moveSpeed * inputAxis);
            }
            else
			{
				movement = Mathf.Min(currVelX, moveSpeed * inputAxis);
			}
        }

        return movement;
	}

    private void GroundedMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            Vector2 currVelocity = body.linearVelocity;

            currVelocity.y = PlayerGravity.Instance != null &&
                             PlayerGravity.Instance.IsGravityReversed()
                             ? -jumpForce
                             : jumpForce;

            body.linearVelocity = currVelocity;

            if (audioSource != null && jumpClip != null)
            {
                audioSource.PlayOneShot(jumpClip);
            }
        }
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.Restart();
        }
    }
}
