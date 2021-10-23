using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
	public GameObject target;
    public Vector3 rotation;

	private void Start()
	{
		target.transform.Rotate(new Vector3(Random.Range(-rotation.x, rotation.x),
			Random.Range(-rotation.y, rotation.y), Random.Range(-rotation.z, rotation.z)));
	}
}
