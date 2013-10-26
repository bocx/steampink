using UnityEngine;
using System.Collections;

public class PinkServer : MonoBehaviour {
	
	void Start () {
		Network.InitializeServer(10, 25000, false);
	}
	
	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log("Player connected");
	}
	
	void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log("Clean up after player " +  player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
}
