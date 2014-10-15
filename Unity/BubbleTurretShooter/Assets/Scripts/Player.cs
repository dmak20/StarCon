using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health = 100;
	public float shake = 0.75f;
	public float shakeAmount = 0.15f;
	public float reduce = 1.0f;
	public DamageFadeInOut damageFader;
	public GUIText healthText;

	void Awake() {

	}

	public void TakeDamage() {

		print ("Taking damage!");
		damageFader.DamageFade ();

		// Play some sort of damage shake
		StartCoroutine (ShakeCamera());

		// Subtract some health
		health -= 10;
		healthText.text = health.ToString ();
	}

	public IEnumerator ShakeCamera() {
		print ("starting shake!");

		float tmpShake = shake;

		while (tmpShake > 0) {
			print ("Shaking: " + shake.ToString ());
			// Shake the camera here
			//transform.localPosition = Random.insideUnitSphere * 0.15f;
			tmpShake -= Time.deltaTime * reduce;

			yield return null;
		}
	
	}
}
