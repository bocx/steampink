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
		Network.Connect("10.45.0.39", 25000);
	}
	
	void OnConnectedToServer() {
		localPlayer = Network.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, 0) as GameObject;

		PlayerController playerController = localPlayer.AddComponent("PlayerController") as PlayerController;
		playerController.winAudio = winAudio;
		playerController.countText = countText;
		playerController.winText = winText;
		playerController.healthDisplay = healthDisplay;
		playerController.centerOfMass = centerOfMass;
		
		ClientCamera camera = Instantiate(cameraPrefab, cameraPrefab.GetComponent<Transform>().position, Quaternion.identity) as ClientCamera;
		
		camera.player = localPlayer;
		
		playerController.speed = 400;
	}
}
