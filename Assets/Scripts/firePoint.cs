using System.Collections;
using UnityEngine;

public class firePoint : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    private bool onCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && onCooldown == false)
        {
            Shoot();
            onCooldown = true;
            StartCoroutine(ShootCooldown(1f));
        }
    }

    IEnumerator ShootCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        onCooldown = false;
    }

    private void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
