using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ChooseTank : MonoBehaviour
{
    
    public List<CostAndText> CostAndTextTank;
  
    public void ChooseTankIndex(int index)
    {
        List<int> Tanks = System_Game.instance.dataTank.Tanks;
        
        if (Tanks.Contains(index)){
            System_Game.instance.dataTank.currentTank = index;
        }else
        {
            BuyTank(index);
            Tanks.Add(index);
            loadTankBought();
            System_Game.instance.dataTank.currentTank = index;
        }
    }
    private void Start()
    {
        foreach (CostAndText index in CostAndTextTank)
        {
            index.CostText.text = index.CostTank.ToString();
        }
        loadTankBought();
    }
    protected void loadTankBought()
    {
        List<int> Tanks = System_Game.instance.dataTank.Tanks;
      
        foreach (int tank in Tanks)
        {
            if(Tanks.Count>1)
                CostAndTextTank[tank].CostText.text = "BOUGHT";
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
