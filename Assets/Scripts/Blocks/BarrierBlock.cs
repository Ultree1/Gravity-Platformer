using UnityEngine;

public class BarrierBlock : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rb;
	private BoxCollider2D bc;
	
	private Color activeColor;
	private Color inactiveColor;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		bc = GetComponent<BoxCollider2D>();

		Color currColor = spriteRenderer.color;
		activeColor = new Color(currColor.r, currColor.g, currColor.b, 1f);
		inactiveColor = new Color(currColor.r, currColor.g, currColor.b, 0.3f);
	}

    public void SwitchOff()
	{
		bc.enabled = false;
		spriteRenderer.color = inactiveColor;
	}

	public void SwitchOn()
	{
		bc.enabled = true;
		spriteRenderer.color = activeColor;
	}
}
