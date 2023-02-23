using UnityEngine;

public class Enemy : MonoBehaviour
{

    [HideInInspector] public float speed = 5f;

    public readonly static int baseHealth = 100;
    public readonly static int baseDamage = 10;

    private static int health = baseHealth;
    private static int damage = baseDamage;

    public static int Killed;

    //public static int Health
    //{
    //    get { return health; }
    //    set { Health = Progression.HealthModifier(); }
    //}

    //public static int Damage
    //{
    //    get { return damage; }
    //    set { Damage = Progression.DamageModifier(); }
    //}

    public GameObject Enemy_death;

    private Rigidbody2D EnemyBody;
    void Start()
    {
        EnemyBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        EnemyBody.velocity = new Vector2(speed, EnemyBody.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(Enemy_death, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitTrigger)
    {
        if (hitTrigger.TryGetComponent<Computador>(out var console))
        {
            console.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(Enemy_death, transform.position, transform.rotation);
        }
    }

    private void OnDestroy()
    {
        Spawner.SetOnScene--;
        Spawner.leftToSpawn--;
        Progression.score++;
        Killed++;
        //Debug.Log("killed " + Killed);
    }
}
