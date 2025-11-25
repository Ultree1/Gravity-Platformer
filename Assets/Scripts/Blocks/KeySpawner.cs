using UnityEngine;
using System.Collections;

public class KeySpawner : MonoBehaviour
{
	[SerializeField] private GameObject key;
	[SerializeField] private LayerMask obstacleLayer;
	[SerializeField] private Transform keySpawnPoint;

	private float areaSize = 0.5f;
    private float checkDuration = 1f;

    private void Start()
	{
		StartCoroutine(CheckSpawn());
	}

    private IEnumerator CheckSpawn()
	{
		float timer = 0f;

        while (timer < checkDuration)
		{
			Collider2D hit = Physics2D.OverlapCircle(keySpawnPoint.position, areaSize, obstacleLayer);

            if (hit != null)
			{
				timer = 0f;
			}
            else
			{
				timer += Time.deltaTime;
			}

            yield return null;
        }

        Instantiate(key, keySpawnPoint.position, Quaternion.identity);
        Destroy(gameObject);
	}
}
