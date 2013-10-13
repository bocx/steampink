﻿using UnityEngine;
using System.Collections;

public class AI_turret : MonoBehaviour {
	public int hitpoints = 100;
	public int trackingRate = 2;
	public float rateOfFire = 2f;
	public CannonBall weaponProjectile;
	
	
	private float shootTimer = 0;	
	
	void OnTriggerStay (Collider target){
		if(target.CompareTag ("Player")){
			//transform.Rotate(transform.forward * trackingRate);
			transform.LookAt(target.transform.position);
			shootTimer += Time.deltaTime;
			if (shootTimer >= rateOfFire){
				CannonBall ball = (CannonBall)Instantiate(weaponProjectile, transform.position + transform.forward * 2 , Quaternion.identity);
				ball.rigidbody.AddForce(transform.forward * 50f, ForceMode.Impulse);
				shootTimer = 0;
			}
		}
	}
	
	public void ApplyDamage(int amount){
		hitpoints -= amount;
		if(hitpoints <= 0){
			Destroy(gameObject);
		}
	}
}
