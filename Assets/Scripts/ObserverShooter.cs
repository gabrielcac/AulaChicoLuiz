using UnityEngine;

public class ObserverShooter : MonoBehaviour
{
	public GameObject spawnPoint;
	public GameObject projectile;

	private void OnEnable()
	{
		ObservableWall.shooters.Add(this);
	}

	private void OnDisable()
	{
		ObservableWall.shooters.Remove(this);
	}

	public void Shoot()
	{
		Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}
}