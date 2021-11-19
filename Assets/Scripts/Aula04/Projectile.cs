using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField]
	private float lifeTime;

	private void Update()
	{
		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0)
		{
			Destroy(gameObject);
		}
	}
}
