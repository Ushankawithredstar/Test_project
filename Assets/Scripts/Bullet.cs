using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    private int damage = 100;

    private Rigidbody2D BulletBody;

    [SerializeField] private GameObject hit_Impact;

    private Collider2D collision;

    public string bullet = "Bullet";

    // Start is called before the first frame update
    void Start()
    {
        BulletBody.GetComponent<Rigidbody2D>();
        BulletBody.velocity = transform.right * speed;

        Invoke(nameof(DestroyBullet), 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);

        if (hitInfo.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(hit_Impact, transform.position, transform.rotation);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
        Instantiate(hit_Impact, transform.position, transform.rotation);
    }
}
