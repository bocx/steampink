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
			for(int i = 0; i < 5; i++){
				CannonBall ball = (CannonBall)Instantiate(prototypeCannonBall, transform.position + transform.right*-0f + transform.up*2f, Quaternion.identity);
				ball.rigidbody.AddForce(transform.up*200f);
				ball.rigidbody.AddForce(transform.right * Random.Range(-10,10));
			}
		}
	}
}