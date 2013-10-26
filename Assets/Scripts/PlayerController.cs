using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	
	public int hitpoints = 100;
	
	public AudioClip winAudio;
	
	private int count;
	
	public GUIText countText;
	
	public GUIText winText;
	
	public GUIText healthDisplay;
	
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
		healthDisplay.text = hitpoints.ToString();
		
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal*0.7f, 0.5f+moveVertical*1.6f, 0f);
		
		Vector3 force = movement * speed * Time.deltaTime;
		
		rigidbody.AddForce(force);
		
	    rigidbody.rotation = SelfRightRotation(rigidbody.rotation, Time.deltaTime/2, force);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
		}
	}
	
	Quaternion SelfRightRotation(Quaternion rotation, float deltaTime, Vector3 force)
	{
		return Quaternion.Slerp(rotation, Quaternion.LookRotation(Vector3.Cross(force, -Vector3.up)), deltaTime * 2f);
	}
	
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		
		if (count >= 10) {
			winText.text = "Suksee!";
			audio.PlayOneShot(winAudio);
		}
	}
	
	public void ApplyDamage(int amount){
		
		if (Network.isServer) {
			return;
		}
		
		hitpoints -= amount;
		if(hitpoints <= 0){
			RemoveBufferedInstantiate(networkView.viewID);
			Network.Destroy(gameObject);
		}
	}
	
	[RPC]
	void RemoveBufferedInstantiate (NetworkViewID viewID) {
	    if (Network.isServer) {
	        Network.RemoveRPCs (viewID);
	    } else {
	        networkView.RPC ("RemoveBufferedInstantiate", RPCMode.Server, viewID);
	    }
	}
}
