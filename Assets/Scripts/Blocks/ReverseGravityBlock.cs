using UnityEngine;

public class ReverseGravityBlock : MonoBehaviour
{
    public void BlockHit(int bulletNum)
    {
        Debug.Log("ReverseGravityBlock HIT!");

        // Reverse gravity for 1 second
        PlayerGravity.Instance.ReverseGravityForSeconds(1f);
    }
}
