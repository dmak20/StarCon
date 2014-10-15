#pragma strict

var movementSpeed : float = 0;
var movementTime : float = 0;
var isMoving : boolean = false;
var lastRotation : Quaternion;

var moveAudio : AudioSource;
var changeAudio : AudioSource;

var startSound : AudioClip;
var moveSound : AudioClip;
var endSound : AudioClip;

function Start()
{
	lastRotation = transform.rotation; //initial data for "last rotation"
}

function Update () 
{
	movementSpeed = Quaternion.Angle(transform.rotation, lastRotation); //get the angle between last rotation and current rotation
	lastRotation = transform.rotation; //save the current rotation to be re-used as "last rotation" next frame

	if(movementSpeed > .05) //we are moving...
	{
		if(!changeAudio.isPlaying) //...but there is no clip playing...
		{
			if(!isMoving) //...we must have just started moving...
			{
				changeAudio.clip = startSound; //set the clip to the "start sound"
				changeAudio.Play(); //play the clip once
				isMoving = true; //now we are officially moving!
			}
			
			if(!moveAudio.isPlaying) //move audio is not playing yet?
			{
				moveAudio.Play(); //play dat funky audio! (it will auto-loop)
			}
		}
		
		//add to the movement time
		movementTime += Time.deltaTime;
	}
	else if(isMoving) //there is no mouse input, but "isMoving" is still on- we must have just stopped!
	{
		moveAudio.Stop(); //stop the move audio
		changeAudio.clip = endSound; //set the clip to the "stop sound"
		isMoving = false; //now we are officially stopped!
		if(movementTime > .5) //only play the stop noise if we have been moving for at least a short bit
		{
			changeAudio.Play(); //play the clip once
		}
		movementTime = 0; //reset movement time
	}
}