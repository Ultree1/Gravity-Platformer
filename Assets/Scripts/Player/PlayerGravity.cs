using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour
{
    public static PlayerGravity Instance;

    private Rigidbody2D body;
    private bool gravityReversed = false;

    private float normalGravityScale;
    private float reverseGravityScale;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        normalGravityScale = body.gravityScale;
        reverseGravityScale = -normalGravityScale;
    }

    public void ReverseGravityForSeconds(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(GravityRoutine(duration));
    }

    private IEnumerator GravityRoutine(float duration)
    {
        gravityReversed = true;
        body.gravityScale = reverseGravityScale;

        yield return new WaitForSeconds(duration);

        gravityReversed = false;
        body.gravityScale = normalGravityScale;
    }

    public bool IsGravityReversed()
    {
        return gravityReversed;
    }
}
