using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

 

    [SerializeField] float bulletSpeed = 5f;

    void Start()
    {
       
    }

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
        
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
