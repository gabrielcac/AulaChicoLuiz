using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public float rotationSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
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
            Debug.Log(transform.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
            Debug.Log(transform.forward);
        }

    }
}
