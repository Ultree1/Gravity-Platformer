using UnityEngine;

public class GunAim : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private Transform bulletSpawnPoint;
    public GameObject bullet;

    private GameObject bulletInst;

    private Vector2 mousePosition;
    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    private void Update()
    {
        GunRotation();
        GunShoot();
    }

    private void GunRotation()
    {
        // rotate gun towards mouse position
        mousePosition = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        // flip gun if backwards
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        gun.transform.localScale = localScale;
    }

    private void GunShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn bullet
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
        }
    }
}
