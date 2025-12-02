using UnityEngine;

public static class Extensions 
{
    private static LayerMask layerMask;

    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        layerMask = LayerMask.GetMask("Default");

        if (rigidbody.bodyType == RigidbodyType2D.Kinematic) {
            return false;
        }

        float length = 0.5f;
        float distance = 0.8f;
        Vector2 size = new Vector2(length, length);

        RaycastHit2D hit = Physics2D.BoxCast(rigidbody.position, size, 0f, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction, LayerMask layerMask)
    {
        if (rigidbody.bodyType == RigidbodyType2D.Kinematic) {
            return false;
        }

        float length = 0.5f;
        float distance = 0.8f;
        Vector2 size = new Vector2(length, length);

        RaycastHit2D hit = Physics2D.BoxCast(rigidbody.position, size, 0f, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }
}
