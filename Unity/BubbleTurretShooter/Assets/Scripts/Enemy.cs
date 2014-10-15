using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Enemy is any object that poses a threat to the player
	// All enemies will have health, motion, deatheffect, spawneffect

	protected GameObject player;
	protected Vector3 targetDir;

	public int health = 100;
	public AudioClip explosionSound;
	public GameObject explodeParticle;
	public GameObject gameManager;
	private GameMode gameScript;

	public bool isMoving = true;

	public Vector3 movement;
	public float speed = 5.0f;
	public bool isDead = false;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		gameManager = GameObject.Find ("GameManager");
		gameScript = gameManager.GetComponent<GameMode> ();
	}

	void Start() {
		//rigidbody.angularVelocity = Random.insideUnitSphere * 10f;
		rigidbody.angularVelocity = Random.insideUnitSphere * 1000f;
		targetDir = Vector3.Normalize(player.transform.position - transform.position);

		//print (targetDir.ToString ());
	}

	void Update() {
		if (isMoving)
			Move ();

		if (isDead) {

			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<Collider>().enabled = false;

//			if (GetComponent<DestroyByTime>() != null)
			//GetComponent<DestroyByTime>().enabled = true;
		}
	}

	public void TakeDamage(int damage)
	{
		// play a hit particle effect at hit point
		health -= damage;
		if (health <= 0) 
		{
			gameScript.addScore(10);

			// Play an explosion particle effect
			//AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			print ("gameObject dead " + this.name);
			StartCoroutine(Death ());
		}
	}

	public void DeathByRadialExplosion()
	{
		Instantiate (explodeParticle, transform.position, Quaternion.identity);
		isDead = true;
		gameScript.addScore (40);
	}

	public virtual IEnumerator Death()
	{
		print ("starting regular death");
		Instantiate (explodeParticle, transform.position, Quaternion.identity);
		isDead = true; //Destroy (gameObject);

		yield return new WaitForSeconds(0.1f);
	}

	// If enemy crashes into player, explode
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			// Issue damage to player
			StartCoroutine(other.gameObject.GetComponent<Player>().ShakeCamera());
			other.gameObject.GetComponent<DamageFadeInOut>().DamageFade();

			StartCoroutine(Death ());
		}
	}

	// Override this class to define custom motions
	public virtual void Move()
	{
		rigidbody.velocity = targetDir * speed * Time.deltaTime;

		// moves in a given direction
		//rigidbody.velocity = (movement * speed * Time.deltaTime);
	}
}
