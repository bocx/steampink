using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public CannonBall prototypeCannonBall;
	public float projectileVelocity = 100;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)){
			projectileVelocity += 10*Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			projectileVelocity -= 10*Time.deltaTime;
	
		}
		bool fire = Input.GetButtonDown("Fire");
		
		if (fire) {
			CannonBall ball = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-0f + transform.up*2f, Quaternion.identity);
			ball.rigidbody.AddForce(transform.up*projectileVelocity,ForceMode.VelocityChange);
			//rigidbody.AddForce(transform.right*50f);
		}
		
	}
}
