using UnityEngine;
using System.Collections;

public class KamakaziEnemy : Enemy {

	// Kamakazi enemy flies directly at player to inflict damage and explode
	//private GameObject player;
	//private Vector3 targetDir;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * 1000f;
	}

	void Update()
	{
		targetDir = Vector3.Normalize(player.transform.position - transform.position);
		//print ("Target Acquired... " + targetDir.ToString ());

		Move ();
	}

	public override void Move ()
	{
		// Use the player as the target to move towards
		rigidbody.velocity = targetDir * speed * Time.deltaTime;
		//transform.rotation = Quaternion.LookRotation (targetDir);
	}

	void OnTriggerEnter(Collider c)
	{

		if (c.tag == "Player") {
			// Subtract some player damage
			//c.TakeDamage();
			c.GetComponent<Player>().TakeDamage();
			Death ();
		}
	}
}
