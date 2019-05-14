using UnityEngine;

internal class ShotController : MonoBehaviour
{
    public float speed;
    private Vector3 target = Vector3.zero;
    public float lifeTime;

    private void Update()
    {
        if (target == null) return;

        transform.position = Vector2.MoveTowards(transform.position,
          target,
          speed * Time.deltaTime);
    }

    internal void Initialize(Vector3 position, float bulletSpeed)
    {
        target = position;
        speed = bulletSpeed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag("Untagged")) 
        Destroy(gameObject);
    }
}