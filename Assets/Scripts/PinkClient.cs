using UnityEngine;
using System.Collections;

public class PinkClient : MonoBehaviour {
	
	public GameObject localPlayer;
	
	public GameObject playerPrefab;
	
	public CannonBall prototypeCannonBall;
	
	public AudioClip winAudio;
	
	public GUIText countText;
	
	public GUIText winText;
	
	public GUIText healthDisplay;
	
	public Vector3 centerOfMass;
	
	public ClientCamera cameraPrefab;
	
	void Start () {
		Network.Connect("127.0.0.1", 25000);
	}
	
	void OnConnectedToServer() {
		localPlayer = Network.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, 0) as GameObject;
		
		Rigidbody rigidbody = localPlayer.AddComponent("Rigidbody") as Rigidbody;
		
		rigidbody.mass = 1;
		rigidbody.drag = 0.5f;
		rigidbody.angularDrag = 0.4f;
		rigidbody.useGravity = true;
		
		PlayerController playerController = localPlayer.AddComponent("PlayerController") as PlayerController;
		playerController.winAudio = winAudio;
		playerController.countText = countText;
		playerController.winText = winText;
		playerController.healthDisplay = healthDisplay;
		playerController.centerOfMass = centerOfMass;
		
		Shoot shoot = localPlayer.AddComponent("Shoot") as Shoot;
		shoot.prototypeCannonBall = prototypeCannonBall;
		
		ClientCamera camera = Instantiate(cameraPrefab, cameraPrefab.GetComponent<Transform>().position, Quaternion.identity) as ClientCamera;
		
		camera.player = localPlayer;
		
		playerController.speed = 400;
	}
}
