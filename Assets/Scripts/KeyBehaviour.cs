using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			CollectKey();
			Destroy(gameObject);
		}
	}

    public void CollectKey()
	{
		LockBlock[] lockInstances = Object.FindObjectsByType<LockBlock>(FindObjectsSortMode.None);
        
        // play unlock sound

        foreach (LockBlock instance in lockInstances)
		{
			instance.unlock();
		}
	}
}
