using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public float rotationSpeed;
    public GameObject target;
    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 1);

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += speed * Time.deltaTime * transform.forward;
            MoveBack();
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += speed * Time.deltaTime * -transform.forward;
            MoveFront();

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
            //Debug.Log(transform.forward);
        }


    }


    void FixedUpdate()
    {
        MoveFront();
        MoveBack();
        RotateDir();
        RotateEsq();

    }

    void MoveBack()
    {
        transform.position += speed * Time.deltaTime * transform.forward;

    }

    void MoveFront()
    {
        transform.position += speed * Time.deltaTime * -transform.forward;

    }

    void RotateDir()
    {
        transform.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
        Debug.Log("apertou A");
    }
    void RotateEsq()
    {
        transform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        //Debug.Log(transform.forward);
    }

    // public void OnTriggerEnter(Collider.objColisao)
    // {
    //     Debug.Log("bateu" + objColisao.name);
    // }
    void SpawnObject()
    {
        Debug.Log("chamou SpawnObject");
        float x = Random.Range(-2.0f, 2.0f);
        float z = Random.Range(-2.0f, 2.0f);
        Instantiate(target, new Vector3(x, 2, z), Quaternion.identity);
    }


}
