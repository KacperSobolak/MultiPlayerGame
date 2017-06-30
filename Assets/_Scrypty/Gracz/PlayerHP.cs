using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHP : NetworkBehaviour {

    float maxHP = 100F;
    [SyncVar]
    public float aktualneHP;
    public Text HP;

	void Start () {
        aktualneHP = maxHP;
        HP.text = aktualneHP.ToString();
    }
	
	void Update () {
        HP.text = aktualneHP.ToString();
    }

    [ClientRpc]
    public void RpcTakeDamage(float ilehp)
    {
            if (aktualneHP > 0)
            {
                aktualneHP -= ilehp;

                if (aktualneHP <= 0)
                {
                    DestroyImmediate(gameObject);
                }
            }

    }

}
