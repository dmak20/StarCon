// Object to follow
var target : Transform;
// Movement damping amount
var positionDamping = 2.0;

function LateUpdate () 
{
	// Damp the position
	//transform.position = Vector3.Lerp(transform.position, target.position, positionDamping * Time.deltaTime);
	transform.position = target.position;
}