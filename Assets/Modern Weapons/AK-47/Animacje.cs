using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacje : MonoBehaviour {

    public Animator Animator;
    bool celewonie = false;

	void Start () {
		
	}
	
	void Update () {
        AnimacjeAK();
	}

    void AnimacjeAK()
    {
        if (Input.GetMouseButton(1) && celewonie == false)
        {
            Animator.SetTrigger("Celowanie");
            celewonie = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Animator.SetTrigger("KoniecCelowania");
            celewonie = false;
        }
    }
}
