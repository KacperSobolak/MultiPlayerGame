using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerCanvas : NetworkBehaviour {

    public Text WynikB;
    [SyncVar]
    int PunktyB;
    public Text WynikR;
    [SyncVar]
    int PunktyR;

    void Start () {
        PunktyB = 0;
        PunktyR = 0;
        WynikB.text = PunktyB.ToString();
        WynikR.text = PunktyR.ToString();
	}
	
	void Update () {
        WynikB.text = PunktyB.ToString();
        WynikR.text = PunktyR.ToString();
    }

    [Command]
    public void CmdDodajpunkty(string druzyna)
    {
        if (druzyna == "Blue")
        {
            PunktyB++;
            WynikB.text = PunktyB.ToString();
        }
        if (druzyna == "Red")
        {
            PunktyR++;
            WynikR.text = PunktyR.ToString();
        }
    }
}
