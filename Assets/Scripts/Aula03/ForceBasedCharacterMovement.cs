using UnityEngine;

namespace Aula03
{
	public class ForceBasedCharacterMovement : MonoBehaviour
	{
		[SerializeField]
		private float acceleration;
		[SerializeField]
		private float maxSpeed;
		[SerializeField]
		private float rotationAcceleration;
		[SerializeField]
		private float maxRotationSpeed;
		[SerializeField]
		private float jumpForce;
		[SerializeField]
		private string groundTag = "Ground";
		
		private Rigidbody rigidBody;
		private Vector3 movementDirection;
		private float rotationDirection;
		private bool jump;
		private bool grounded;
		
		private void Awake()
		{
			rigidBody = GetComponent<Rigidbody>();
		}
		
		private void Update()
		{
			// Rotação
			if (Input.GetKey(KeyCode.A))
			{
				rotationDirection = -1;
			}
			if (Input.GetKey(KeyCode.D))
			{
				rotationDirection = 1;
			}

			if (grounded)
			{
				// Movimentação
				if (Input.GetKey(KeyCode.W))
				{
					movementDirection += transform.forward;
				}
				if (Input.GetKey(KeyCode.S))
				{
					movementDirection -= transform.forward;
				}
				if (movementDirection != Vector3.zero)
				{
					movementDirection.Normalize();
				}

				// Pulo
				if (Input.GetKey(KeyCode.Space))
				{
					jump = true;
				}
			}
		}
		
		private void FixedUpdate()
		{
			// Movimentação
			if (movementDirection != Vector3.zero)
			{
				if (Vector3.Dot(rigidBody.velocity, movementDirection) < maxSpeed)
				{
					rigidBody.AddForce(acceleration * movementDirection, ForceMode.Acceleration);
				}
				movementDirection = Vector3.zero;
			}

			// Rotação
			if (rotationDirection != 0)
			{
				if (rigidBody.angularVelocity.y * rotationDirection < maxRotationSpeed)
				{
					rigidBody.AddTorque(rotationAcceleration * rotationDirection * Vector3.up, ForceMode.Acceleration);
				}
				rotationDirection = 0;
			}
			
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
				rigidBody.drag = 1;
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			if (collision.collider.tag == groundTag)
			{
				grounded = false;
				rigidBody.drag = 0;
			}
		}
	}
}