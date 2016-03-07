using UnityEngine;
using System.Collections;

using UnityEngine.Networking;
//using UnityEngine.Network;



// /*
public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GUI.Button(new Rect (500, 100, 100, 50), "liczba graczy1:");	
	
	}
	
	// Update is called once per frame
	void Update () {
		//OnGUI ();
		GUI.Box(new Rect (500, 100, 100, 50), "liczba graczy12:" + playersAmount);
		//GUI.Box(new Rect (500, 100, 100, 50), "liczba graczy12:" + addPlayer());

		//var GetComponent<GUIText>().GetComponent<GUIText>() = "liczba graczy" + playersAmount;
	}

	private const string typeName = "GameName123";
	private const string gameName = "Game123";
	public float playersAmount = 0f;

	//public GameObject playerPrefab; //for sp/resp

	public GameObject playerPrefab;

	private void StartServer() {
		//MasterServer.ipAddress = "127.0.0.1"; //main //last
		MasterServer.ipAddress = "67.225.180.24"; 
		//MasterServer.port = 25000; //last
		MasterServer.port = 23466; //

		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);

		//MasterServer.ipAddress = "127.0.0.1"; //main
	}

	private float addPlayer() {
		playersAmount++;
		Debug.Log("Added player");
		return(playersAmount);
	}

	/*
	getPlayerAmount() {
	}
	*/

	//spawn/resp
	private void SpawnPlayer() {
		Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
		//playersAmount++;
		addPlayer();
	}

	private void OnServerInitialized() {
		Debug.Log("Beeeeng Server Initializied");
		Debug.Log("Server: " + MasterServer.ipAddress);
		SpawnPlayer(); 
		Debug.Log("player spawned !!!!!");
		//playersAmount++;
	}

	void OnGUI() {

		//need to update
		GUI.Button(new Rect (500, 10, 150, 20), "liczba graczy:" + playersAmount);	
		

		//dla nowych
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button(new Rect(100, 100, 150, 50), "server start btn"))
				StartServer();
			
			if (GUI.Button(new Rect(100, 200, 150, 50), "refresh host list"))
				RefreshHostList();
			
			//Debug.Log ("jest: " + hostList[1].gameName);
			if (hostList != null) {
				//Debug.Log ("hostlist fun, cos jest");
				for (int i = 0; i < hostList.Length; i++) {
					Debug.Log ("hostlist fun, cos jest in");
					//Debug.Log ("jest: " + hostList[i].gameName);
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 50), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}

		}
	}




	//master lokalny
	//MasterServer.ipAddress = "127.0.0.1";

	//join i host lista:
	private HostData[] hostList;

	private void RefreshHostList() {
		MasterServer.RequestHostList (typeName);
	}

	void OnMasterServerEvent(MasterServerEvent msEvent) {
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList ();
	}

	private void JoinServer(HostData hostData) {
		Network.Connect(hostData);
	}

	void OnConnectedToServer() {
		Debug.Log ("server Joined!!!");
		SpawnPlayer();
		//playersAmount++;
	}







}
// */



