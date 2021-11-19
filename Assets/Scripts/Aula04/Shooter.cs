using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField]
	private Projectile projectilePrefab;
	[SerializeField]
	private float shootingForce;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
		projectile.GetComponent<Rigidbody>().AddForce(shootingForce * transform.forward, ForceMode.Impulse);
	}
}
