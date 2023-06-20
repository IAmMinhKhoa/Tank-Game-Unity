using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ChooseTank : MonoBehaviour
{
    
    public List<CostAndText> CostAndTextTank;
    public GameObject TextWarningCoin;  
    public void ChooseTankIndex(int index)
    {
        List<int> Tanks = System_Game.instance.dataTank.Tanks;
        
        if (Tanks.Contains(index)){
            System_Game.instance.dataTank.currentTank = index;
        }else
        {
            if(CostAndTextTank[index-1].CostTank<=Coin_Manager.instance.coin){
                BuyTank(index);
                Tanks.Add(index);
                loadTankBought();
                System_Game.instance.dataTank.currentTank = index;
            }else{
                TextWarningCoin.SetActive(true);
            }
           
        }
    }
    private void Start()
    {
        foreach (CostAndText index in CostAndTextTank)
        {
            index.CostText.text = index.CostTank.ToString()+" Coin";
        }
        loadTankBought();
    }
    protected void loadTankBought()
    {
        List<int> Tanks = System_Game.instance.dataTank.Tanks;
      
        foreach (int tank in Tanks)
        {
            if(tank!=0)
                CostAndTextTank[tank-1].CostText.text = "BOUGHT";
        }

    }
    void BuyTank(int index)
    {
        int coin = Coin_Manager.instance.coin - CostAndTextTank[index - 1].CostTank;
        Coin_Manager.instance.coin = coin;
    }
    [System.Serializable]
    public class CostAndText
    {
        public int CostTank;
        public TMP_Text CostText;
    }
}
