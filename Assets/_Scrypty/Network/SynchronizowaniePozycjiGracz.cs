using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SynchronizowaniePozycjiGracz : NetworkBehaviour {

    public float PositionLerpSpeed = 10.0F, rotationLerpSpeed = 15.0F;

    [SyncVar]
    Quaternion rotation;
    [SyncVar]
    Vector3 position;

	void Start () {
		
	}
	
	void FixedUpdate () {
        TransmitData();
        RecieveData();
	}

    [ClientCallback]
    void TransmitData()
    {
        if (isLocalPlayer)
        {
            CmdSyncData(transform.rotation, transform.position);
        }
    }

    void RecieveData()
    {
        if (!isLocalPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * PositionLerpSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationLerpSpeed);
        }
    }

    [Command]
    void CmdSyncData(Quaternion rot, Vector3 pos)
    {
        rotation = rot;
        position = pos;
    }
}
