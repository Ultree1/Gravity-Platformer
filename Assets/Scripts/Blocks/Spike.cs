using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip damageClip;

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) {
            StartCoroutine(HandlePlayerHit());
		}
        else if (other.gameObject.layer == LayerMask.NameToLayer("Block"))
		{
			Destroy(other.gameObject);
		}
	}

    private IEnumerator HandlePlayerHit()
    {
        if (audioSource != null && damageClip != null)
        {
            audioSource.volume = 1f;
            audioSource.PlayOneShot(damageClip);
            yield return new WaitForSeconds(0.3f);
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
        }

        GameManager.Instance.GameOver();
    }
}
