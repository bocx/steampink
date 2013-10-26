using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public CannonBall prototypeCannonBall;
	
	public float timeUntilShoot = 0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!networkView.isMine) {
			return;
		}
		
		float fire = Input.GetAxis("Fire");
		
		timeUntilShoot -= Time.deltaTime;
		
		if (fire > 0f && timeUntilShoot < 0) {
			timeUntilShoot = 0.3f;
			
			networkView.RPC("InstantiateCannonBall", RPCMode.All, transform.position + transform.right*-5f + transform.up*2f, transform.right*-2000f);
			rigidbody.AddForce(transform.right*50f);
		}
		
	}
	
	[RPC]
	void InstantiateCannonBall(Vector3 pos, Vector3 force) {
		CannonBall ball = (CannonBall)Instantiate(prototypeCannonBall, pos, Quaternion.identity);
		ball.rigidbody.AddForce(force);
	}
}
