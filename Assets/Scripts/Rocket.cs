using UnityEngine;

public class Rocket : MonoBehaviour
{
	public float speed = 10;

	void Start()
	{
		Destroy(gameObject,3f);
	}

	void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision other)
	{
		Destroy(gameObject);
		print("boom!");

		var health = other.gameObject.GetComponent<Health>();
		if (health != null)
		{
			health.Damage(10);
		}
	}
}