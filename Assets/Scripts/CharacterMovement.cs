using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public float speed;

	void Update()
    {
		if(Input.GetKey(KeyCode.W))
		{
			transform.position += speed * Time.deltaTime * Vector3.forward;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position += speed * Time.deltaTime * Vector3.back;
		}
	}
}
