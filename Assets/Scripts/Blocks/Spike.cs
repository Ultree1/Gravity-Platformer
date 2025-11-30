using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) {
			GameManager.Instance.GameOver();
		}
        else if (other.gameObject.layer == LayerMask.NameToLayer("Block"))
		{
			Destroy(other.gameObject);
		}
	}
}
