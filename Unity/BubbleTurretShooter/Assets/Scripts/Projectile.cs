using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float mySpeed = 10;
	public float maxDistance = 800;
	public int damage = 10;
	public AudioClip hitSound;

	private float distanceTraveled = 0;
	private GameObject player;
	private MovePlayer playerMover;
	private float playerSpeed;

	void Awake() {
		playerMover = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovePlayer>();
	}

	// Update is called once per frame
	void Update () {
		playerSpeed = Mathf.Clamp(playerMover.speed * 100, 0, 1000);
//		print ("player Speed: " + playerSpeed.ToString () + " " + mySpeed.ToString ());
		transform.Translate(Vector3.forward * (mySpeed + playerSpeed) * Time.deltaTime);
		distanceTraveled+= mySpeed * Time.deltaTime;
		if(distanceTraveled > maxDistance)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision)
	{

	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RadialExplosion")
		{
			AudioSource.PlayClipAtPoint(hitSound, transform.position, 0.5f);
			collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
			Destroy (gameObject);
		}
	}
}
