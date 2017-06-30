using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Text nicktext;

	void Start () {
	    if (PlayerPrefs.HasKey("Nick") == true)
        {
            nicktext.text = PlayerPrefs.GetString("Nick");
        }
	}
	
	void Update () {
		
	}

    public void UstawNick()
    {
        nicktext.text = PlayerPrefs.GetString("Nick");
    }

}
