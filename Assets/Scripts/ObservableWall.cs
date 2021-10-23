using System.Collections.Generic;
using UnityEngine;

public class ObservableWall : MonoBehaviour
{
	public static List<ObserverShooter> shooters = new List<ObserverShooter>();

	private void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Projectile>() != null)
		{
			Destroy(other.gameObject);

			for(int i = 0; i < shooters.Count; i++)
			{
				shooters[i].Shoot();
			}
		}
	}
}
