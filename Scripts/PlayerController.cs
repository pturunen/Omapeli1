using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private bool dead;
	private int count;
	
	
	void Start()
	{   dead = false;
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	//joka kerta before rendering the code
	void Update()
	{
		
	}
	
	//just before any physic calculation,rigidbody react physic
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
		//Time needed to make this independent
		rigidbody.AddForce(movement * speed * Time.deltaTime);
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count +1;
			SetCountText();
		}
		
		if(other.gameObject.tag == "fallout")
		{
			dead = true;
			winText.text = "GAME OVER!";
			shutRobots();
			GameObject.Find("Player").SetActive(false);
		}
	}
	
	void shutRobots()
	{
		GameObject[] robots;
		robots = GameObject.FindGameObjectsWithTag("robot");
		foreach(GameObject robot in robots)
		{
			robot.SetActive(false);
		}
	}
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if(count >= 12)
		{
			winText.text = "YOU WIN!";
			shutRobots();
		}
	}
	
	void LateUpdate()
	{
		if(dead)
		{
			transform.position = new Vector3(0,4,0);
			GameObject.Find("Main Camera").transform.position = new Vector3(0,4,-10);
			dead = false;
		}
	}
	
}
