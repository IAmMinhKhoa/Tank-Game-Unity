using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Control_UI : MonoBehaviour
{
   public TMP_Text textCount;
   [SerializeField] GameObject ScreenOver;
    [SerializeField] GameObject ScreenWin;

    void FixedUpdate()
   {
        GameOver();
        WinGame();
        textCount.text=System_Game.instance.countEnemies.ToString();
   }
   void GameOver(){
        if((System_Game.instance.ArPlayer.Length==0))
        {
            ScreenOver.SetActive(true);
            Sound_Manager.instance.StopSound(SoundType.TankTrack);
        }
   }
    void WinGame()
    {
        if (System_Game.instance.countEnemies == 0)
        {
            ScreenWin.SetActive(true);
            Sound_Manager.instance.StopSound(SoundType.TankTrack);
        }
    }
   
}
