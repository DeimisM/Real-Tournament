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
            weapon.recoilAngle = 5;
            weapon.isAutoFire = false;
        }
        else
        {
            weapon.bulletsPerShot = 1;
            weapon.recoilAngle = 0;
            weapon.isAutoFire = true;
        }
    }
}