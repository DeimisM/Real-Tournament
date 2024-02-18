using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int bulletsInMag;
    public int maxBullets = 10;

    bool isReloading;
    public bool isAutomatic = true;

    public float fireInterval = 0.1f;
    public float fireCooldown;
    public float reloadTime = 2;

    private void Start()
    {
        if (bulletsInMag == 0)
        {
            bulletsInMag = maxBullets;
        }
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        // semi-auto fire
        if(!isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        // automatic fire
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    async void Reload()
    {
        if (bulletsInMag == maxBullets) return;
        if (isReloading) return;


        isReloading = true;

        print("reloading");
        await new WaitForSeconds(reloadTime);
        bulletsInMag = maxBullets;

        isReloading = false;
        
    }

    void Shoot()
    {
        if(isReloading) return;
        if (fireCooldown > 0) return;

        if (bulletsInMag <= 0)
        {
            Reload();
            return;
        }


        bulletsInMag--;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
