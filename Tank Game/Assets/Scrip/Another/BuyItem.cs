using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ChooseTank;

public class BuyItem : MonoBehaviour
{
    public List<PriceAndCount> PriceAndCounts;
    public List<ItemData> Items;
    public List<int> PriceItem;
    public GameObject TextWarningCoin;
    void Start()
    {
        UpdateQuantityItem();
        UpdatePriceItem();
    }

    void UpdateQuantityItem()
    {
       for(int i = 0; i < PriceAndCounts.Count; i++)
        {
            PriceAndCounts[i].Count.text = Items[i].Quantity.ToString();
        }
    }
    void UpdatePriceItem()
    {
        for(int i=0;i < PriceAndCounts.Count; i++)
        {
            PriceAndCounts[i].Price.text = PriceItem[i].ToString();
        }
    }

    public void BuyItemIndex(int index )
    {
        if (checkPrice(index))
        {
            Items[index].Quantity++;
            Coin_Manager.instance.coin -= PriceItem[index];
            UpdateQuantityItem();
        }
        else
        {
            TextWarningCoin.SetActive(true);
        }
    }
    bool checkPrice(int index)
    {
        if (Coin_Manager.instance.coin > (int)PriceItem[index])
        {
            return true;
        }
        return false;
    }
    [System.Serializable]
    public class PriceAndCount
    {
        public TMP_Text Count;
        public TMP_Text Price;
    }
}
