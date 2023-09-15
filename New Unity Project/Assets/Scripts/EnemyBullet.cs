using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 20f;

	// Start is called before the first frame update
	void Start()
    {
		rb.velocity = transform.forward * (-speed);
    }

	void OnTriggerEnter(Collider collider)
	{
		//Enemy enemy = collider.GetComponent<Enemy>();
		if (collider.tag == "Player")
		{
			Destroy(gameObject);
		}
		if (collider.tag == "WallLimits")
		{
			Destroy(gameObject);
		}
	}
}
