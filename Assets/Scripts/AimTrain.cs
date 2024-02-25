using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTrain : MonoBehaviour
{
    //                      add Health, AimTrain scripts to the object thats going to be shot
    public Health health;

    //                   set values that are correct for you
    public float maxX;
    public float minX;

    public float maxY;
    public float minY;

    public float maxZ;
    public float minZ;

    private void Start()
    {
        health.onDamage.AddListener(UpdateLocation);
    }

    private void UpdateLocation()
    {
        var x = Random.Range(maxX, minX);
        var y = Random.Range(maxY, minY);
        var z = Random.Range(maxZ, minZ);

        transform.position = new Vector3(x, y, z);
    }
}
