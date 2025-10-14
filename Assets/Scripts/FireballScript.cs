using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private Rigidbody2D body;
    private Transform t;
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 5f;
    public float gravity = 10f;
    public float lifetime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(new Vector2(0, -gravity));
        body.linearVelocity = new Vector2(horizontalSpeed, Mathf.Min(verticalSpeed, body.linearVelocity.y));
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // The normal vector points away from the surface of the colliding object.
            // If the normal's Y component is approximately 1, it means the collision
            // occurred on the bottom of this object (the block).
            if (Mathf.Abs(contact.normal.y - 1) < 0.1f) // Use a small tolerance for float comparison
            {
                body.linearVelocity = new Vector2(horizontalSpeed, verticalSpeed);
                break; // Exit loop after finding a contact from below
            }
        }
    }
}
