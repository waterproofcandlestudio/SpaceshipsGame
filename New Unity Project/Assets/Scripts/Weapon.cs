using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public AudioClip shot;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Shoot();
			AudioSource.PlayClipAtPoint(shot, transform.position);
		}
	}

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
