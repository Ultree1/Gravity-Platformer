using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gravArrows;
    public List<Image> childImages = new List<Image>();

    private BulletCycle bulletCycle;
    private int bulletType;
    private int currentBullet;

    private float activeAlpha = 1f;
    private float inactiveAlpha = 0.3f;

    private void Start()
	{
		bulletCycle = GameObject.FindWithTag("Gun").GetComponent<BulletCycle>();
        bulletType = bulletCycle.bulletType;
        currentBullet = bulletType;

        Image[] imagesArray = gravArrows.GetComponentsInChildren<Image>(true);
        childImages.AddRange(imagesArray);

        DeactivateAll();
        Activate(bulletType);
	}

    private void Update()
	{
        bulletType = bulletCycle.bulletType;

		if (currentBullet != bulletType)
		{
            currentBullet = bulletType;
            DeactivateAll();
            Activate(currentBullet);
		}
	}

    private void DeactivateAll()
	{
		foreach (Image img in childImages)
		{
			Color currColor = img.color;
            currColor.a = inactiveAlpha;
            img.color = currColor;

		}
	}

    private void Activate(int bulletType)
	{
		Color currColor = childImages[bulletType].color;
        currColor.a = activeAlpha;
        childImages[bulletType].color = currColor;
	}
}
