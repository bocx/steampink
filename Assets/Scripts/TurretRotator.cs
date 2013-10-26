using UnityEngine;
using System.Collections;

public class TurretRotator : MonoBehaviour {
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(-Vector3.forward,rotationSpeed);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(Vector3.forward,rotationSpeed);
		}
	}
}
