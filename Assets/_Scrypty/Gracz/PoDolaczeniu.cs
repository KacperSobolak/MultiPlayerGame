using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PoDolaczeniu : NetworkBehaviour {

    public NetworkStartPosition[] NSpawnPoints;
    public NetworkStartPosition[] CSpawnPoints;
    public string Druzyna;
    public int playerID;
    [SyncVar]
    public string label;

    void Start () {
        Spawn();
        if (isLocalPlayer)
        {
            playerID = int.Parse(netId.ToString());
            Debug.Log("Network ID gracza = " + playerID);
            name = playerID.ToString();
        }
        SetupPlayer();

	}
	
	void Update () {
		
	}

    void Spawn()
    {
        if (isLocalPlayer)
        {
            if (isServer)
            {
                Debug.Log("JestemServer");
                Vector3 NSpawnPoint = Vector3.zero;
                NSpawnPoint = NSpawnPoints[Random.Range(0, NSpawnPoints.Length)].transform.position;
                transform.position = NSpawnPoint;
                Druzyna = "Blue";
                GameObject capsule = GameObject.Find("Capsule");
                Renderer rend = capsule.GetComponent<Renderer>();
                if (isLocalPlayer)
                {
                    rend.material.color = Color.black;
                }
                Debug.Log(Druzyna);
            }
            else if(isClient)
            {
                Debug.Log("JestemKlient");
                Vector3 CSpawnPoint = Vector3.zero;
                CSpawnPoint = CSpawnPoints[Random.Range(0, NSpawnPoints.Length)].transform.position;
                transform.position = CSpawnPoint;
                Druzyna = "Red";
                GameObject capsule = GameObject.Find("Capsule");
                Renderer rend = capsule.GetComponent<Renderer>();
                if (isLocalPlayer)
                {
                    rend.material.color = Color.magenta;
                }
                Debug.Log(Druzyna);
            }
        }
    }

    public int GetID()
    {
        return playerID;
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            TransmitName();
        }
        else
        {
            name = label;
        }
    }

    [ClientCallback]
    void TransmitName()
    {
        CmdTransmitName(name);
    }

    [Command]
    void CmdTransmitName(string n)
    {
        label = n;
    }

    void SetupPlayer()
    {
        GameController gc = GameObject.Find("GameController").gameObject.GetComponent<GameController>();
        gc.RegisterPlayer(this.gameObject, int.Parse(this.netId.ToString()));
    }

}
