using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawnowanie : NetworkBehaviour {

    public NetworkStartPosition[] NSpawnPoints;
    public NetworkStartPosition[] CSpawnPoints;
    public string Druzyna;

    [RPC]
    void Start () {
        if (isServer)
        {
            Druzyna = "Blue";
        }
        if (isClient)
        {
            Druzyna = "Red";
        }
        RpcSpawn();
        Debug.Log(Druzyna);
	}
	
	void Update () {
		
	}

    void RpcSpawn()
    {
        if (isLocalPlayer)
        {
            if (isServer)
            {
                Debug.Log("JestemServer");
                Vector3 NSpawnPoint = Vector3.zero;
                NSpawnPoint = NSpawnPoints[Random.Range(0, NSpawnPoints.Length)].transform.position;
                transform.position = NSpawnPoint;
            }
            else if(isClient)
            {
                Debug.Log("JestemKlient");
                Vector3 CSpawnPoint = Vector3.zero;
                CSpawnPoint = CSpawnPoints[Random.Range(0, NSpawnPoints.Length)].transform.position;
                transform.position = CSpawnPoint;
            }
        }
    }
}
