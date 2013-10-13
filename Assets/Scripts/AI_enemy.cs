using UnityEngine;
using System.Collections;

public class AI_enemy : MonoBehaviour {
	
	public int hitpoints = 100;	
		
	public void ApplyDamage(int amount){
		hitpoints -= amount;
		if(hitpoints <= 0){
			Destroy(gameObject);
		}
	}
}
