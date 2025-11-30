using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // This will be called from the Button's OnClick event
    public void PlayClick()
    {
        if (clickClip != null)
        {
            audioSource.PlayOneShot(clickClip);
        }
    }
}
