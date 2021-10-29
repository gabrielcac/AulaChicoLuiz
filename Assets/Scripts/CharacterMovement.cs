using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;

	private Rigidbody rigidbody;
	private Quaternion amountToRotate = Quaternion.identity;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
    {
		// Movimento
		if(Input.GetKey(KeyCode.W))
		{
			//transform.position += speed * Time.deltaTime * transform.forward;
			rigidbody.velocity = speed * transform.forward;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			//transform.position += speed * Time.deltaTime * -transform.forward;
			rigidbody.velocity = speed * -transform.forward;
		}
		else
		{
			rigidbody.velocity = Vector3.zero;
		}
		
		// Rotação
		if (Input.GetKey(KeyCode.A))
		{
			//transform.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
			amountToRotate *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.D))
		{
			//transform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
			amountToRotate *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
		}
	}

	void FixedUpdate()
	{
		if (amountToRotate != Quaternion.identity)
		{
			rigidbody.rotation *= amountToRotate;
			amountToRotate = Quaternion.identity;
		}
	}
}
