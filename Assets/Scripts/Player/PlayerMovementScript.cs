using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask ground;
    public float moveSpeed = 5f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;

    private float inputAxis;


    public bool grounded { get; private set; }
    public bool isJumping { get; private set; }

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
	{
        Restart();

        grounded = body.Raycast(Vector2.down, ground);
        if (grounded)
		{
            isJumping = body.linearVelocity.y > 0f;
			GroundedMovement();
		}

		HorizontalMovement();
	}

    private void HorizontalMovement()
	{
        inputAxis = Input.GetAxis("Horizontal");
		body.linearVelocity = new Vector2(inputAxis * moveSpeed, body.linearVelocity.y);
	}

    private void GroundedMovement()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
		{
			Vector2 currVelocity = body.linearVelocity;
            currVelocity.y = jumpForce;
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
