using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Bron : NetworkBehaviour { 

    float range = 10.0f;
    Vector3 fwd;
    RaycastHit _hit;
    float Zadawanie_HP = 50F;

    GameObject ServerCanvasGO;
        
	void Start () {
        ServerCanvasGO = GameObject.Find("Skrypty");

		if (isLocalPlayer)
        {
            Debug.Log("Lokalny Gracz");
        }
        else if (!isLocalPlayer)
        {
            Debug.Log("Nie lokalny gracz");
        }
    }
	
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        strzel();
	}

    void strzel()
    {
        Komunikat kom = gameObject.GetComponent<Komunikat>();
        Spawnowanie spaw = gameObject.GetComponent<Spawnowanie>();
        ServerCanvas sc = ServerCanvasGO.GetComponent<ServerCanvas>();

        fwd = transform.TransformDirection(Vector3.forward);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.DrawRay(transform.position, fwd, Color.green);
                Debug.Log("Strzał");
                if (Physics.Raycast(transform.position, fwd, out _hit))
                {
                    if (_hit.transform.tag == "Enemy")
                    {
                        PlayerHP php = _hit.collider.gameObject.GetComponent<PlayerHP>();
                        Debug.Log("Tafiono przeciwnkia");
                        kom.pojawienie("Trafiono przeciwnika");
                        CmdTakeDamage(Zadawanie_HP, _hit);
                        if (php.aktualneHP <= 0)
                        {
                            Debug.Log("Zabito przeciwnika");
                            kom.pojawienie("Zabito przeciwnika");
                        }
                    }
                    else
                    {
                        Debug.Log("Nietrafiono");
                        kom.pojawienie("Nie trafiono");
                    }
                }
            }
    }

    void CmdTakeDamage(float ile, RaycastHit hit)
    {
        Komunikat kom = gameObject.GetComponent<Komunikat>();
        Spawnowanie spaw = gameObject.GetComponent<Spawnowanie>();
        ServerCanvas sc = ServerCanvasGO.GetComponent<ServerCanvas>();

        PlayerHP php = hit.collider.gameObject.GetComponent<PlayerHP>();

        php.RpcTakeDamage(ile);
    }


}
