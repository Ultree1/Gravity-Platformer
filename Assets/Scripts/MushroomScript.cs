using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    private Rigidbody2D body;
    private Transform t;
    private int direction = 1;
    public float movementSpeed = 2f;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
            foreach (ContactPoint2D contact in collision.contacts)
        {

            print(contact.normal.x);
            // The normal vector points away from the surface of the colliding object.
            // If the normal's Y component is approximately 1, it means the collision
            // occurred on the bottom of this object (the block).
            if (Mathf.Abs(contact.normal.x) > 0.8f) // Use a small tolerance for float comparison
            {
                direction *= -1;
                break; // Exit loop after finding a contact from below
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = new Vector2(movementSpeed * direction, body.linearVelocity.y);
    }
}
