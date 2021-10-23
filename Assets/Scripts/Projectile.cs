using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float lifeTime;
	public float speed;

	private void Start()
	{
		Destroy(gameObject, lifeTime);

		GetComponent<Rigidbody>().velocity = speed * transform.forward;
	}

	public void SetSpeed(float speed)
	{
		GetComponent<Rigidbody>().velocity = speed * transform.forward;
	}
}
