using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float speedForce;
    [SerializeField] int ammo;
    public bool isShot;
    public bool stillAmmo;

    void Awake()
    {
        ammo = 100;
        stillAmmo = true;
        speedForce = 40f;
        isShot = false;
    }

    void Update()
    {
        if (stillAmmo)
        {
            shootProjectile();

            if (ammo <= 0)
            {
                stillAmmo = false;
                Debug.Log("You have " + ammo + " ammo left. Can't shoot");
            }
        }
    }

    private void shootProjectile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 offset = new Vector3(0f, 0f, 1f);
            GameObject bullet = Instantiate(projectile, transform.position + offset, Quaternion.Euler(90f, 0f, 0f));
            Rigidbody bulletRig = bullet.GetComponent<Rigidbody>();
            bulletRig.AddForce(transform.up * speedForce, ForceMode.Impulse);
            isShot = true;
            ammo--;
            Debug.Log("Ammo: " + ammo + " left");
        }
    }
}
