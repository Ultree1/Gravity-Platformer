using UnityEngine;

public class LuckyBlockScript : MonoBehaviour
{
    public GameObject mushroom;
    public GameObject flower;
    public GameObject coinEffect;
    public string item = "coin";
    private Transform t;
    private Rigidbody2D body;
    void Awake()
    {
        t = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // The normal vector points away from the surface of the colliding object.
                // If the normal's Y component is approximately 1, it means the collision
                // occurred on the bottom of this object (the block).
                if (Mathf.Abs(contact.normal.y - 1) < 0.1f) // Use a small tolerance for float comparison
                {
                    print("Block hit from below by Player!");
                    OnPlayerHit();
                    break; // Exit loop after finding a contact from below
                }
            }
        }
    }

    void OnPlayerHit()
    {
        switch (item)
        {   
            case "coin":
                PlayerMovementScript.coins += 1;
                Vector2 coinpos = new Vector2(t.position.x, t.position.y);
                Instantiate(coinEffect, coinpos, Quaternion.identity);
                print(PlayerMovementScript.coins);
                break;

            case "mushroom":
                Vector2 mushpos = new Vector2(t.position.x, t.position.y + 1);
                Instantiate(mushroom, mushpos, Quaternion.identity);
                break;

            case "flower":
                Vector2 flowerPos = new Vector2(t.position.x, t.position.y + 1);
                Instantiate(flower, flowerPos, Quaternion.identity);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
