using UnityEngine;
using System.Collections;

public class SmoothFollow_Rotation : MonoBehaviour {
	public Transform target;
	// Rotation damping amount
	public float rotationDamping = 3.0f;

	void LateUpdate() {
		// Damp the rotation
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);

	}
}
