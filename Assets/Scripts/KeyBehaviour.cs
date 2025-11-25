using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public void Collect()
	{
		GameObject[] lockInstances = GameObject.FindGameObjectsWithTag("Lock");
        
        // play unlock sound

        foreach (GameObject instance in lockInstances)
		{
			Destroy(instance, 0.1f);
		}
	}
}
