using UnityEngine;
using System.Collections;

public class EnemyRadialExplosion : Enemy {
	public GameObject RadialExplosion;

	public override IEnumerator Death ()
	{
		// before instantiating the parent we want to get our child collider
		// and tell it to set off explosions in anyone in our radius

		print ("starting radial destruction..." + transform.position.ToString ());
		Instantiate(RadialExplosion, transform.position, Quaternion.identity);
		if (health <= 0) {

			// Instantiate a radial explosion

			//	GameObject radialExplosion = transform.GetChild (0).gameObject;
			//	StartCoroutine (radialExplosion.GetComponent<DestroyInRadius> ().DestroySequence ());
			// yield return new WaitForSeconds (5f);
		}
		//print ("enabled child and child script");
		Instantiate (explodeParticle, transform.position, Quaternion.identity);
		//Destroy (gameObject);

		isDead = true;

		yield return null;
	}
}
