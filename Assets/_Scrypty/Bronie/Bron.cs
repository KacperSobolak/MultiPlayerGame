using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Bron : NetworkBehaviour
{

    Vector3 fwd;
    RaycastHit _hit;
    float Zadawanie_HP = 50F;
    GameObject gamec;

    public int mojepunkty;
    [SyncVar]
    public int punkty;

    GameObject ServerCanvasGO;

    void Start()
    {
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

    void Update()
    {
        if (isLocalPlayer && Input.GetMouseButtonDown(0))
        {
            strzel();
        }
        if (isLocalPlayer && Input.GetKey("k"))
        {
            DodajPunkty();
        }
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            ShareResult();
        }
        else if (!isLocalPlayer)
        {
            mojepunkty = punkty;
        }
    }

    void strzel()
    {
        Komunikat kom = gameObject.GetComponent<Komunikat>();
        PoDolaczeniu spaw = gameObject.GetComponent<PoDolaczeniu>();

        fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd, Color.green);
        if (isLocalPlayer)
        {
            Debug.Log("Strzał");
            if (Physics.Raycast(transform.position, fwd, out _hit))
            {
                if (_hit.transform.tag == "Player")
                {
                    CmdTakeDamage(Zadawanie_HP, int.Parse(_hit.collider.name), int.Parse(netId.ToString()));
                }
            }
        }
    }


    [Command]
    void CmdTakeDamage(float amount, int IDplayer, int Mojeid)
    {
        GameObject player = GameObject.Find(IDplayer.ToString());
        PlayerStats php = player.GetComponent<PlayerStats>();
        php.TakeDamage(amount);
        if (php.aktualneHP <= 0)
        {
            //DodajPunkty(Mojeid);
        }
    }

    void DodajPunktyl()
    {
        if (isLocalPlayer)
        {
            Debug.Log("Komenda dziala");
            PoDolaczeniu pd = gameObject.GetComponent<PoDolaczeniu>();
            GameController gc = GameObject.Find("GameController").gameObject.GetComponent<GameController>();

            if (pd.Druzyna == "Blue")
            {
                gc.RpcDodajPunkty("Blue");
            }
            else if (pd.Druzyna == "Red")
            {
                gc.RpcDodajPunkty("Red");
            }
        }
    }

    void ShareResult()
    {
        ServerCanvas sc = GameObject.Find("Skrypty").gameObject.GetComponent<ServerCanvas>();
        PoDolaczeniu pd = gameObject.GetComponent<PoDolaczeniu>();

        if (pd.Druzyna == "Blue")
        {
            TransmitResult(punkty);
        }
        else if (pd.Druzyna == "Red")
        {
            TransmitResult(punkty);
        }
    }

    [ClientCallback]
    void TransmitResult(int punkty)
    {
        CmdTransmitResult(punkty);
    }

    [Command]
    public void CmdTransmitResult(int p)
    {
        punkty = p;
    }

    [ClientCallback]
    void DodajPunkty()
    {
        Debug.Log("I like this");
        DodajPunktyl();
    }
}
