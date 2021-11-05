using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterMovement : MonoBehaviour
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float maxSpeed;
	[SerializeField]
	private float rotationSpeed;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private string groundTag = "Ground";

	private Rigidbody rigidBody;
	private Vector3 toMove;
	private Quaternion toRotate;
	private bool jump;
	private bool grounded;

	private void Awake()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		// Movimentação
		if(Input.GetKey(KeyCode.W))
		{
			toMove += Time.deltaTime * transform.forward;
		}
		if (Input.GetKey(KeyCode.S))
		{
			toMove -= Time.deltaTime * transform.forward;
		}

		// Rotação
		if (Input.GetKey(KeyCode.A))
		{
			toRotate *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.D))
		{
			toRotate *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
		}

		// Pulo
		if(grounded && Input.GetKey(KeyCode.Space))
		{
			jump = true;
		}
	}

	private void FixedUpdate()
	{
		// Movimentação
		if (toMove != Vector3.zero)
		{
			Vector3 movement = new Vector3(rigidBody.velocity.x, 0, rigidBody.velocity.z) + (speed * toMove);
			if(movement.magnitude > maxSpeed)
			{
				movement = movement.normalized * maxSpeed;
			}
			rigidBody.velocity = new Vector3(movement.x, rigidBody.velocity.y, movement.z);
		}
		else
		{
			rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
		}
		toMove = Vector3.zero;

		// Rotação
		rigidBody.rotation *= toRotate;
		toRotate = Quaternion.identity;

		// Pulo
		if(jump)
		{
			rigidBody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
			jump = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == groundTag)
		{
			grounded = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.tag == groundTag)
		{
			grounded = false;
		}
	}
}
