#pragma strict

//Vector3
var bullitPrefab:Transform;
var LookAtTarget:Transform;
var damp = 6.0;
var savedTime = 0;

function Update () {
	
	if(LookAtTarget)
	{
	//check difference of two points in space
	var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
	//current, saved,overtime
	transform.rotation = Quaternion.Slerp(transform.rotation,rotate,Time.deltaTime * damp);
	var seconds : int = Time.time;
	var oddeven = (seconds % 2);
	if (oddeven)
	{
		Shoot(seconds);
	}
	
	}
	
	//transform.LookAt(LookAtTarget);

	//default spacebar
	//if(Input.GetButtonDown("Jump"))
	//{
	//own identity and position
	//	}
}

function Shoot(seconds)
{
if (seconds!=savedTime){

	var bullit = Instantiate(bullitPrefab,
						transform.Find("spawPoint").transform.position,
						Quaternion.identity);
	bullit.rigidbody.AddForce(transform.forward * 2000);	
	
	savedTime = seconds;	
	}										

}