using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float spawnTime = 1;
	public GameObject[] enemies;
	public float closeRange =  10f;			// The closest an enemy can spawn to player


	private float countdown;

	// Use this for initialization
	void Start () {
		countdown = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0) 
		{
			transform.position = GetRandomVector ();

			int randomEnemy = Random.Range (0, 2);
			Instantiate (enemies[randomEnemy], transform.position, Quaternion.identity);
			countdown = spawnTime;
		}
	}

	Vector3 GetRandomVector()
	{
		Vector3 randomLocation = new Vector3(Random.Range (0, 200) - 100, Random.Range (0, 200) - 100, Random.Range (0, 200) - 100);

		while (randomLocation.x < closeRange && randomLocation.x > -closeRange ||
		       randomLocation.y < closeRange && randomLocation.y > -closeRange ||
		       randomLocation.z < closeRange && randomLocation.z > -closeRange)
			randomLocation = new Vector3(Random.Range (0, 200) - 100, Random.Range (0, 200) - 100, Random.Range (0, 200) - 100);

		return randomLocation;
	}
}
