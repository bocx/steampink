using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public CannonBall prototypeCannonBall;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float fire = Input.GetAxis("Fire");
		
		if (fire > 0f) {
			CannonBall ball = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-5f + transform.up*2f, Quaternion.identity);
			ball.rigidbody.AddForce(transform.right*-2000f);
			rigidbody.AddForce(transform.right*50f);
		}
		
	}
}
