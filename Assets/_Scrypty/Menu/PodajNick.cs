using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PodajNick : NetworkBehaviour {

    public GameObject PodajNickMenu;
    public GameObject GrajMenu;
    string nickname;
    public Text TextInputfield;

	void Start () {
		if (PlayerPrefs.HasKey("Nick") == true)
        {
            PodajNickMenu.SetActive(false);
            GrajMenu.SetActive(true);
        }
        else
        {
            PodajNickMenu.SetActive(true);
            GrajMenu.SetActive(false);
        }
	}
	
	void Update () {
		
	}

    public void DalejBTN()
    {
        Menu mu = GetComponent<Menu>();

        nickname = TextInputfield.text.ToString();
        PlayerPrefs.SetString("Nick", nickname);
        PodajNickMenu.SetActive(false);
        GrajMenu.SetActive(true);
        mu.UstawNick();
    }
}
