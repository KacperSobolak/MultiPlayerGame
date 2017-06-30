using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Dolaczanie_Tworzenie_serwera : NetworkBehaviour {

    public NetworkManager manager;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void StartServer()
    {
        manager.StartHost();
    }

    public void JoinServer()
    {
        manager.StartClient();
    }
}
