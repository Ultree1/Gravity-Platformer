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

    private int BulletType = 0;
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
			if (BulletType >= 3)
            {
				BulletType = 0;
			}
            else
			{
				BulletType++;
			}
		}

        if (scrollValue.y < 0f)
		{
			if (BulletType <= 0)
			{
				BulletType = 3;
			}
            else
			{
				BulletType--;
			}
		}

	}

    private void ChangeBulletType()
	{
        if (gunAim != null)
		{
		    if (BulletType == 0)
			{
				bullet = rightBullet;
			}

            else if (BulletType == 1)
		    {
                bullet = upBullet;
		    }

            else if (BulletType == 2)
		    {
                bullet = leftBullet;
		    }
            
            else if (BulletType == 3)
		    {
                bullet = downBullet;
		    }

            gunAim.bullet = bullet;
        }
	}
}
