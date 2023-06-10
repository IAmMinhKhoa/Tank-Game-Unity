using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Use_Item_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BoomOject;
    protected GameObject[] ListPlayer;
    protected GameObject Player;
    void Start()
    {
        ListPlayer = GameObject.FindGameObjectsWithTag("Player");

        if (ListPlayer.Count() != 0)
        {
            Player = ListPlayer[0];
        }
    }
    public void UseBoom()
    {
        UseObject(BoomOject);
    }
    protected void UseObject(GameObject Oject)
    {
        if (Player != null)
        {
            /*Vector2 PSplayer = new Vector2(Player.transform.position.x, Player.transform.position.y);
            Instantiate(Oject, PSplayer, Player.transform.rotation);*/
            Vector2 playerPos = Player.transform.position;
            Vector2 playerForward = Player.transform.right;

            Vector2 objectPos = playerPos - playerForward.normalized * 0.7f; // 0.5f là kho?ng cách gi?a player và ??i t??ng m?i
            

            GameObject newObject = Instantiate(Oject, objectPos,Player.transform.rotation);

           
        }
           
    }
}
