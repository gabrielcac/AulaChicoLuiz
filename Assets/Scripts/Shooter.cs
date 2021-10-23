using UnityEngine;

public class Shooter : MonoBehaviour
{
	public Transform spawnPoint;
	public Projectile bullet;
	public float bulletSpeed;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Projectile instantiated = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
			instantiated.SetSpeed(bulletSpeed);
		}
	}
}
