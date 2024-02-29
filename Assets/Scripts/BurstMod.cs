using UnityEngine;

public class BurstMod : MonoBehaviour
{
    public Weapon weapon;
    public bool isBursting;

    public void Burst()
    {
        isBursting = !isBursting;

        if (isBursting)
        {
            weapon.bulletsPerShot = 3;
            weapon.spreadlAngle = 5;
            weapon.isAutoFire = false;
        }
        else
        {
            weapon.bulletsPerShot = 1;
            weapon.spreadlAngle = 0;
            weapon.isAutoFire = true;
        }
    }
}