using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public Rigidbody rb;

	KillCounter killCounterScript;
	public int enemiesKilled = 0;
	public Text numbEnemiesKilled;

	private void Update()
	{
		numbEnemiesKilled.text = enemiesKilled.ToString();
	}

	// Use this for initialization
	void Start()
	{
		killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
		rb.velocity = transform.forward * speed;
	}

    void OnTriggerEnter(Collider collider)
	{
		 //Enemy enemy = collider.GetComponent<Enemy>();
		if (collider.tag == "Enemy")
		{
			killCounterScript.AddKill();

			Destroy(gameObject);
		}
		if (collider.tag == "WallLimits")
		{
			Destroy(gameObject);
		}
	}
}
