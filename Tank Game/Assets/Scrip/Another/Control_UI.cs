using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Control_UI : MonoBehaviour
{
   public TMP_Text textCount;
   [SerializeField] GameObject ScreenOver;
   
   void Update()
   {
    GameOver();
    textCount.text=System_Game.instance.countEnemies.ToString();
   }
   void GameOver(){
    if(System_Game.instance.ArPlayer.Length==0)
    {
        ScreenOver.SetActive(true);
    }
   }
}
