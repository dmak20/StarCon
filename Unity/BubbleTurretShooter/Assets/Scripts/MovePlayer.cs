using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	public GUITexture throttle;
	public float speed;
	public GameObject worldLimits;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerExit(Collider c)
	{
//		if (c.tag == "WorldLimits") {
//			// Check whether we've gone out of x,y, or z bounds and put us on the opposite side inside the outside bounds.
//			if (transform.position.x > c.bounds.max.x)
//				transform.position = new Vector3(c.bounds.min.x + gameObject.GetComponent<SphereCollider>().bounds.size.x,
//				                                 transform.position.y,
//				                                 transform.position.z);
//
//			if (transform.position.x < c.bounds.min.x)
//				transform.position = new Vector3(c.bounds.max.x - gameObject.GetComponent<SphereCollider>().bounds.size.x,
//				                                 transform.position.y,
//				                                 transform.position.z);
//
//			if (transform.position.y > c.bounds.max.y)
//				transform.position = new Vector3(transform.position.x,
//				                                 c.bounds.min.y + gameObject.GetComponent<SphereCollider>().bounds.size.y,
//				                                 transform.position.z);
//
//			if (transform.position.y < c.bounds.min.y)
//				transform.position = new Vector3(transform.position.x,
//				                                 c.bounds.max.y - gameObject.GetComponent<SphereCollider>().bounds.size.y,
//				                                 transform.position.z);
//
//			if (transform.position.z > c.bounds.max.z)
//				transform.position = new Vector3(transform.position.x,
//				                                 transform.position.y,
//				                                 c.bounds.min.z + gameObject.GetComponent<SphereCollider>().bounds.size.z);
//
//			if (transform.position.z < c.bounds.min.z)
//				transform.position = new Vector3(transform.position.x,
//				                                 transform.position.y,
//				                                 c.bounds.max.z - gameObject.GetComponent<SphereCollider>().bounds.size.z);
//
//			print (c.bounds.min.x.ToString ());
//
//		}
	}
	
	// Update is called once per frame
	void Update () {
//		print (throttle.pixelInset.ToString ());
		float throttlePos = throttle.gameObject.transform.position.y;
//		print (throttle.gameObject.transform.position.ToString ());
		throttlePos = ((throttlePos - 0.1f) / 0.2f) * 100 * Time.deltaTime;
		Vector3 forwardSpeed = Vector3.forward * throttlePos * speed;
//		print ("speed from player: " + forwardSpeed.ToString ());

		transform.Translate (forwardSpeed);
		//rigidbody.velocity = forwardSpeed;
	}
}
