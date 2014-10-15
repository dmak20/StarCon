#pragma strict

var myGuns : Transform[];
var projectile : GameObject;
var laserAudio : AudioSource;
var joystickTexture : GUITexture;
var playAudio : boolean;

private var reloadTime : float;
private var nextFireTime : float;
private var gunIndex : int = 0;

function Start()
{
	reloadTime = myGuns[0].animation.clip.length;
}

function Update () 
{

	// Make sure the finger is pressed over the joystick GUITEXTURE
	// loop through each touch to see if they're over the joystick
	var count = Input.touchCount;

	for(var i : int = 0;i < count; i++)
	{
		var touch : Touch = Input.GetTouch(i);			
		var guiTouchPos : Vector2 = touch.position;
		
		if (joystickTexture.HitTest( touch.position ))
		{
			if (Time.time > nextFireTime)
				FireAllGuns();
		}
	
	}


		if(Input.GetMouseButtonDown(0))
		{
			if(Time.time > nextFireTime)
			{
				FireAllGuns();
			}
		}
//		if(Input.GetMouseButtonDown(1))
//		{
//			if(Time.time > nextFireTime)
//			{
//				FireSingleGun();
//			}
//		}

}

function FireAllGuns()
{	
	nextFireTime = Time.time + reloadTime;	
	for(theGun in myGuns)
	{
		if(!theGun.animation.isPlaying)
		{
			Instantiate(projectile, theGun.Find("_MuzzlePosition").position, theGun.Find("_MuzzlePosition").rotation);
			theGun.animation.Play();
			laserAudio.pitch = .5;
			laserAudio.volume = .25;
			if (playAudio)
				laserAudio.Play();
		}

	}
}

function FireSingleGun()
{	
	nextFireTime = Time.time + (reloadTime/myGuns.length);
	Instantiate(projectile, myGuns[gunIndex].Find("_MuzzlePosition").position, myGuns[gunIndex].Find("_MuzzlePosition").rotation);
	myGuns[gunIndex].animation.Play();
//	laserAudio.pitch = 1;
//	laserAudio.volume = .125;
//	laserAudio.Play();
	gunIndex++;
	if(gunIndex == myGuns.length)
		gunIndex = 0;
}