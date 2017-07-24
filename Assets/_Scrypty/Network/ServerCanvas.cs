using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerCanvas : NetworkBehaviour {

    public Text WynikB;
    /*[SyncVar]
    public int PunktyB;*/
    public Text WynikR;
    /*[SyncVar]
    public int PunktyR;*/
    public Text komunikat;

    void Start () {
        /*PunktyB = 0;
        PunktyR = 0;
        WynikB.text = PunktyB.ToString();
        WynikR.text = PunktyR.ToString();*/
        komunikat.enabled = false;
	}
	
	void Update () {
        GameController gc = GameObject.Find("GameController").gameObject.GetComponent<GameController>();

        WynikB.text = gc.punktyB.ToString();
        WynikR.text = gc.punktyR.ToString();
    }

    public void Wyswietl_Kominikat(string komunikatsc)
    {
        komunikat.enabled = true;
        komunikat.text = komunikatsc;
    }

    public void Wyczysc_komunikat()
    {
        komunikat.text = "";
        komunikat.enabled = false;
    }
}
