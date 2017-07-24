using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerStats : NetworkBehaviour {

    float maxHP = 100F;
    [SyncVar]
    public float aktualneHP;
    public Text HP;
    NetworkStartPosition[] NSpawn;
    NetworkStartPosition[] CSpawn;

    void Start () {
        aktualneHP = maxHP;
        HP.text = aktualneHP.ToString();
    }
	
	void Update () {
        HP.text = aktualneHP.ToString();
    }

    public void TakeDamage(float ilehp)
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
