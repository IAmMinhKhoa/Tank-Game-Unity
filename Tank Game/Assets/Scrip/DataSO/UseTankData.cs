using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UseTankData", menuName = "Data/UseTankData")]
public class UseTankData : ScriptableObject
{
    //0 red
    //1 black
    //2 green
    public int currentTank;
    public List<int> Tanks;
}
