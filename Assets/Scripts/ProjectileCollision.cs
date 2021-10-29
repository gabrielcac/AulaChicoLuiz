using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject collisionEffect;

	private void OnCollisionEnter(Collision collision)
	{
		Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
		Instantiate(collisionEffect, collision.contacts[0].point, rotation);
	}
}
