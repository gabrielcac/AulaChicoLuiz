using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAim : MonoBehaviour
{
	public GameObject laserPoint;

	private void FixedUpdate()
	{
		if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 100))
		{
			laserPoint.SetActive(true);
			laserPoint.transform.position = hitInfo.point;
			Debug.Log($"Objeto colidido: {hitInfo.collider.transform.root.name}, Distancia = {hitInfo.distance}");
		}
		else
		{
			laserPoint.SetActive(false);
		}
	}
}
