using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public float framerate = 1f / 2f;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void OnEnable()
	{
		InvokeRepeating("Animate", framerate, framerate);
	}

    private void OnDisable()
	{
        CancelInvoke("Animate");
		spriteRenderer.sprite = sprites[1];
	}

    private void Animate()
	{
		frame ++;

        if (frame >= sprites.Length)
		{
			frame = 0;
		}

        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
	}
}
