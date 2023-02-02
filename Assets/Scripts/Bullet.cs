using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    public int damage = 100;

    public Rigidbody2D BulletBody;

    public GameObject Hit_Impact;

    public static Collider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        BulletBody.GetComponent<Rigidbody2D>();
        BulletBody.velocity = transform.right * speed;

        StartCoroutine(BulletDestroy(0.3f));
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);

        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(Hit_Impact, transform.position, transform.rotation);
    }

    IEnumerator BulletDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Instantiate(Hit_Impact, transform.position, transform.rotation);
    }
}
