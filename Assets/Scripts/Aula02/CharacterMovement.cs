using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;

	void Update()
    {
		if(Input.GetKey(KeyCode.W))
		{
			transform.position += speed * Time.deltaTime * transform.forward;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position += speed * Time.deltaTime * -transform.forward;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
		}
	}
}
