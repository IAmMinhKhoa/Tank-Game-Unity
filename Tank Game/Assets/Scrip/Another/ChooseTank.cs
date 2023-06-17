using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChooseTank : MonoBehaviour
{
    public void ChooseTankIndex(int index)
    {
        System_Game.instance.dataTank.currentTank = index;
        //.LoadScene("StartGame");
    }
}
