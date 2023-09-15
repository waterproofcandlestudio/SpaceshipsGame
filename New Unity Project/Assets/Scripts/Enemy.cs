using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public AudioClip explosion;
    public GameObject explosionParticle;

    void OnTriggerEnter(Collider collider)
	{
		//Enemy enemy = collider.GetComponent<Enemy>();
		if (collider.tag == "Bullet")
		{
            Destroy(gameObject);

            Instantiate(explosionParticle, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosion, transform.position);
        }
        if (collider.tag == "WallLimits")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Player")
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
