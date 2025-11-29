using UnityEngine;

public class Switch : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	[SerializeField] private LayerMask obstacleLayer;
	[SerializeField] private Transform originPoint;

	private float areaSize = 1f;

	private Color unpressedColor;
	private Color pressedColor;

	private bool pressed;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		Color currColor = spriteRenderer.color;
		unpressedColor = new Color(currColor.r, currColor.g, currColor.b, 1f);
		pressedColor = new Color(currColor.r, currColor.g, currColor.b, 0.3f);

		spriteRenderer.color = unpressedColor;
		pressed = false;

	}

    private void Update()
	{
		Collider2D hit = Physics2D.OverlapCircle(originPoint.position, areaSize, obstacleLayer);
        if (hit != null)
		{
			if (!pressed)
			{
				DeactivateBarrier();
				spriteRenderer.color = pressedColor;
				pressed = true;
			}
		}
		else
		{
			if (pressed)
			{
				ActivateBarrier();
				spriteRenderer.color = unpressedColor;
				pressed = false;
			}
		}
	}

	public void DeactivateBarrier()
	{
		BarrierBlock[] barrierInstances = FindObjectsByType<BarrierBlock>(FindObjectsSortMode.None);
		foreach (BarrierBlock instance in barrierInstances)
		{
			instance.SwitchOff();
		}
		
	}

	public void ActivateBarrier()
	{
		BarrierBlock[] barrierInstances = FindObjectsByType<BarrierBlock>(FindObjectsSortMode.None);
		foreach (BarrierBlock instance in barrierInstances)
		{
			instance.SwitchOn();
		}
		
	}
}
