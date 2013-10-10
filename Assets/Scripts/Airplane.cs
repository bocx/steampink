using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour {
	
	public float rotationRate = 100;
	public float engineThrust = 1000;
	public float liftCoefficient = 100f;
	
	private Vector3 originPoint;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		originPoint = transform.InverseTransformPoint(new Vector3(0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
		velocity = rigidbody.velocity;
		rigidbody.AddForce(transform.up * velocity.x * liftCoefficient * Time.deltaTime,ForceMode.Force);
		
	}
	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.UpArrow)){
			rigidbody.AddForce(transform.right * engineThrust * Time.deltaTime, ForceMode.Acceleration);
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(Vector3.forward * rotationRate * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(-Vector3.forward * rotationRate * Time.deltaTime);
		}
	}
}
