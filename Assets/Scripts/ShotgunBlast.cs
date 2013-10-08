using UnityEngine;
using System.Collections;

public class ShotgunBlast : MonoBehaviour {
	
	public CannonBall prototypeCannonBall;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		bool fire = Input.GetButtonDown("Fire");
		
		if (fire) {
			CannonBall ball1 = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-0f + transform.up*2f, Quaternion.identity);
			ball1.rigidbody.AddForce(transform.up*20f);
			ball1.rigidbody.AddForce(transform.right *-20);
			CannonBall ball2 = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-0f + transform.up*2f, Quaternion.identity);
			ball2.rigidbody.AddForce(transform.up*20f);
			ball2.rigidbody.AddForce(transform.right*-10);
			CannonBall ball3 = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-0f + transform.up*2f, Quaternion.identity);
			ball3.rigidbody.AddForce(transform.up*20f);
			ball3.rigidbody.AddForce(transform.right*00);
			CannonBall ball4 = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-0f + transform.up*2f, Quaternion.identity);
			ball4.rigidbody.AddForce(transform.up*20f);
			ball4.rigidbody.AddForce(transform.right*10);
			CannonBall ball5 = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-0f + transform.up*2f, Quaternion.identity);
			ball5.rigidbody.AddForce(transform.up*20f);
			ball5.rigidbody.AddForce(transform.right*20);
			//rigidbody.AddForce(transform.right*50f);
		}
		
	}
}