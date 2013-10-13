using UnityEngine;
using System.Collections;

/**
 * Used for instantiation in Shoot.cs
 **/
public class CannonBall : MonoBehaviour {
	
	public Transform explosionPrefab;
	
	public float timeToLive, safetyTimer;
	
	private bool primed = false;
	private float timer = 0;
	
	void OnCollisionEnter(Collision coll) {
		if (primed){
			coll.gameObject.SendMessage("ApplyDamage", 20, SendMessageOptions.DontRequireReceiver);	
			
			ContactPoint contact = coll.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;		
			Instantiate(explosionPrefab, pos, rot);
			Destroy(gameObject);
		}
	}
	void FixedUpdate(){
		timer += Time.deltaTime;
		if(timer > safetyTimer){
			primed = true;
		}
		timeToLive -= Time.deltaTime;
		if (timeToLive <= 0){			
			Instantiate(explosionPrefab, transform.position, transform.localRotation);
			Destroy(gameObject);
		}
	}
			
}
			
