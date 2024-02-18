using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    public float speed = 20;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.Damage(10);
        }
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
