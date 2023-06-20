using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spam_Player : MonoBehaviour
{
    [SerializeField] GameObject TankRed;
    [SerializeField] GameObject TankPurble;
    [SerializeField] GameObject TankGreen;
    [SerializeField] Transform SpamPoint;
    protected int IDtank;
    private void Awake()
    {
        IDtank=System_Game.instance.dataTank.currentTank;
        if (IDtank == 0)
        {
            Instantiate(TankRed, SpamPoint.position, Quaternion.identity);
        }else if(IDtank == 1)
        {
            Instantiate(TankPurble, SpamPoint.position, Quaternion.identity);
        }else if (IDtank == 2)
        {
            Instantiate(TankGreen, SpamPoint.position, Quaternion.identity);
        }
    }

}
