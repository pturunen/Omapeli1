using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Update is called once per frame
	//Now modify the rotate movement in every frame
	//transform rotate is already set
	void Update () {
	transform.Rotate(new Vector3(15,30,45)* Time.deltaTime);
	}
}
