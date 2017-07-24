using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    public GameObject[] players;
    public GameObject blueteamplayer;
    public GameObject redteamplayer;
    public GameObject ServerCanvas;

    public int AlivePlayers;
    public int LiczbaGraczy = 0;
    bool rozgrzewkab = false;
    float rozgrzewkat = 30;
    float rozgrzewkatl;
    [SyncVar]
    public int punktyB;
    [SyncVar]
    public int punktyR;

	void Start () {
        rozgrzewkatl = rozgrzewkat;
    }
	
	void Update () {
        /*if (rozgrzewkab)
        {
            ServerCanvas sc = GameObject.Find("Skrypty").GetComponent<ServerCanvas>();
            rozgrzewkatl -= Time.deltaTime;
            Debug.Log(Mathf.Round(rozgrzewkatl));
            sc.Wyswietl_Kominikat("Koniec rozgrzewki za " + Mathf.Round(rozgrzewkatl) + " sekund");
        }*/
    }

    public void ReSpawn()
    {
        PoDolaczeniu pd = gameObject.GetComponent<PoDolaczeniu>();
        
        //NSpawn = pd.NSpawnPoints;
        //CSpawn = pd.CSpawnPoints;
    }

    public void RegisterPlayer(GameObject player, int netid)
    {
        Debug.Log("Register Player");
        LiczbaGraczy += 1;
        /*if (LiczbaGraczy == 1)
        {
            StartCoroutine(rozgrzewka());
            rozgrzewkab = true;
        }
        else if (LiczbaGraczy == 2 && rozgrzewkatl > 10)
        {
            rozgrzewkatl = 10;
            rozgrzewkat = 10;
        }*/
        players[netid] = player;
    }

    /*IEnumerator rozgrzewka()
    {
        Debug.Log("Rozgrzewka start");
        yield return new WaitForSeconds(rozgrzewkat);
        Debug.Log("Koniec rozgrzewki");
        Koniec_rozgrzewki();
    }*/

    /*void Koniec_rozgrzewki()
    {
        rozgrzewkab = false;
        ServerCanvas sc = GameObject.Find("Skrypty").GetComponent<ServerCanvas>();
        sc.Wyczysc_komunikat();
    }*/

    [RPC]
    public void RpcDodajPunkty(string druzyna)
    {
        ServerCanvas sc = ServerCanvas.GetComponent<ServerCanvas>();

        if (druzyna == "Blue")
        {
            punktyB++;
        }
        else if (druzyna == "Red")
        {
            punktyR++;
        }
        Debug.Log("Dodano punkty dla druzyny " + druzyna);
    }

}
