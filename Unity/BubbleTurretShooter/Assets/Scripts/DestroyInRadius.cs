using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DestroyInRadius : MonoBehaviour {

	List<Transform> destroyUs = new List<Transform>();

	void Start()
	{
		StartCoroutine(WaitToCollect ());
	}

	IEnumerator WaitToCollect()
	{
		yield return new WaitForSeconds (0.5f);
		print ("starting destroy sequence...");
		print (transform.position.ToString ());
		StartCoroutine(DestroySequence ());
	}

	void OnTriggerEnter(Collider c)
	{
//		print ("Object triggered " + c.name);
//		print ("List of objects: " + destroyUs.ToString ());
//		print (c.name);
		if (c.tag == "Enemy" || c.tag == "RadialExplosion") {

			destroyUs.Add (c.gameObject.transform);
			PrintList ();
		}

		destroyUs = destroyUs.Distinct ().ToList ();

		SortTargetList ();
	}

	void SortTargetList()
	{
		// Todo: Remove null references
		destroyUs.Sort (delegate(Transform c1, Transform c2) {
			if (c1 == null) {
				destroyUs.Remove (c1);
				return 0;
			}
			else if (c2 == null) {
				destroyUs.Remove (c1);
				return 1;
			}
			else
				return Vector3.Distance (this.transform.position, c1.transform.position).CompareTo ((Vector3.Distance (this.transform.position, c2.transform.position)));

		});
	}

	void PrintList()
	{
		string output = "" + this.name;

		foreach (Transform t in destroyUs)
			output += "object: " + t.name + "\n";

		output += destroyUs.Count.ToString ();

//		print(output);
	}

	void OnTriggerExit(Collider c)
	{
//		print (destroyUs.ToString ());
//		print (c.name);
		if (c.tag == "Enemy") {
			destroyUs.Remove (c.gameObject.transform);
		}
	}

	public IEnumerator DestroySequence()
	{
		//print ("Destroy sequence initiated..." + destroyUs.Count.ToString ());

		foreach (Transform g in destroyUs) {
			if (g != null && !g.GetComponent<Enemy>().isDead) {
				if (g.tag == "RadialExplosion")
					StartCoroutine (g.gameObject.GetComponent<EnemyRadialExplosion> ().Death ());
				else
					g.gameObject.GetComponent<Enemy> ().DeathByRadialExplosion ();
			}

			yield return new WaitForSeconds (0.05f);
		}

		foreach (Transform g in destroyUs) {
			g.gameObject.GetComponent<DestroyByTime>().enabled = true;

			yield return null;
		}
	}
}
