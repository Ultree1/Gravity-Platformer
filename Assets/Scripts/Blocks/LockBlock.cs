using UnityEngine;

public class LockBlock : MonoBehaviour
{
    public void unlock()
	{
		Destroy(gameObject, 0.1f);
	}
}
