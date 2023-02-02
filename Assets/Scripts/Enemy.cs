using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    [HideInInspector] public float speed = 5f;
     public static float health = 100f;
     public static int damage = 10;

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
            Destroy(gameObject); //object destroyed
            Instantiate(Enemy_death, transform.position, transform.rotation); //death animation
            Progression.score++;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitTrigger)
    {
        
        if (hitTrigger.TryGetComponent<Computador>(out var console))
        {
            console.TakeDamage(damage);
        }

        Spawner.onScene--;
        Spawner.leftToSpawn--;
        Destroy(gameObject); //object destroyed
    }

}
