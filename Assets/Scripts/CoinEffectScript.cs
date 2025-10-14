using UnityEngine;

public class CoinEffectScript : MonoBehaviour
{
    private Transform t;
    private Rigidbody2D body;
    public float riseTime = 0.5f;
    public float riseSpeed = 20.0f;
    private float timer = 0f;
    private float direction = 1f;
    private float originalHeight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalHeight = t.position.y;
    }

    void Awake()
    {
        t = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= riseTime/2)
        {
            direction = -1f;
        }
        

        t.position = new Vector2(t.position.x, t.position.y + (riseSpeed*Time.deltaTime* direction));
        if (t.position.y < originalHeight)
        {
            Destroy(gameObject);
        }
    }
}
