using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Komunikat : MonoBehaviour {

    public Text Info;

	void Start () {
        Info.text = "";
	}
	
	void Update () {
		
	}

    public void pojawienie(string text)
    {
        StopAllCoroutines();
        Info.text = text;
        StartCoroutine(komunikat_reset());
    }

    IEnumerator komunikat_reset()
    {
        yield return new WaitForSeconds(1);
        Info.text = "";
    }
}
