﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeleteNoLocalPlayerComponent : NetworkBehaviour {

    [SerializeField]
    Behaviour[] component;

	void Start () {
		if (!isLocalPlayer)
        {
            foreach (Behaviour behaviour in component)
            {
                DestroyImmediate(behaviour);
            }
            DestroyImmediate(GetComponent<CharacterController>());
            DestroyImmediate(GetComponent<Rigidbody>());
        }
	}
	
	void Update () {
		
	}
}