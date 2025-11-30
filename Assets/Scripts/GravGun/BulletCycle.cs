using UnityEngine;
using UnityEngine.InputSystem;

public class BulletCycle : MonoBehaviour
{
    [SerializeField] private GameObject upBullet;
    [SerializeField] private GameObject downBullet;
    [SerializeField] private GameObject leftBullet;
    [SerializeField] private GameObject rightBullet;
    private GameObject bullet;

	private Vector2 scrollValue;
    private GunAim gunAim;

    public int bulletType = 3;
    // Type 0: Right
    // Type 1: Up
    // Type 2: Left
    // Type 3: Down

    private void Start()
	{
		gunAim = GetComponent<GunAim>();
	}
    
    private void Update()
	{
		CycleBullet();
        ChangeBulletType();
	}

    private void CycleBullet()
	{
        // cycle bullet type on scrolling mouse button
        scrollValue = Mouse.current.scroll.ReadValue();
        
		if (scrollValue.y > 0f)
		{
			if (bulletType >= 3)
            {
				bulletType = 0;
			}
            else
			{
				bulletType++;
			}
		}

        if (scrollValue.y < 0f)
		{
			if (bulletType <= 0)
			{
				bulletType = 3;
			}
            else
			{
				bulletType--;
			}
		}

	}

    private void ChangeBulletType()
	{
        if (gunAim != null)
		{
		    if (bulletType == 0)
			{
				bullet = rightBullet;
			}

            else if (bulletType == 1)
		    {
                bullet = upBullet;
		    }

            else if (bulletType == 2)
		    {
                bullet = leftBullet;
		    }
            
            else if (bulletType == 3)
		    {
                bullet = downBullet;
		    }

            gunAim.bullet = bullet;
        }
	}
}
