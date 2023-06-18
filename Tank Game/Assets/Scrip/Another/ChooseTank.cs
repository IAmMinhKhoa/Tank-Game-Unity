using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChooseTank : MonoBehaviour
{
    public void ChooseTankIndex(int index)
    {
        
        if(System_Game.instance.dataTank.Tanks.Contains(index)){
            System_Game.instance.dataTank.currentTank = index;
        }else
        {
            System_Game.instance.dataTank.Tanks.Add(index);
            System_Game.instance.dataTank.currentTank = index;
        }
        //.LoadScene("StartGame");
    }
}
