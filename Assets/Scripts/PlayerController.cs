using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	
	private int count;
	
	public GUIText countText;
	
	public GUIText winText;
	
	public Vector3 centerOfMass;
	
	void Start	()
	{
		count = 0;
		SetCountText();
		winText.text = "";
		
		rigidbody.centerOfMass = centerOfMass;
	}
	
	void Update()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
		
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal*0.7f, 0.5f+moveVertical*1.6f, 0f);
		
		rigidbody.AddForce(movement * speed * Time.deltaTime);
		
		
	    rigidbody.rotation = SelfRightRotation(rigidbody.rotation, Time.deltaTime/2);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
		}
	}
	
	Quaternion SelfRightRotation(Quaternion rotation, float deltaTime)
	{
		return Quaternion.Slerp(rotation, Quaternion.AngleAxis(0, Vector3.left), deltaTime);
	}
	
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		
		if (count >= 10) {
			winText.text = "Suksee!";
		}
	}
}
