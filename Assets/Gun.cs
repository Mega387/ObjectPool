using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = objectPool.TryGetFromPool();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }
}