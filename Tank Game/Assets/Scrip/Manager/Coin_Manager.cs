using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Manager : MonoBehaviour
{

    public int coin = 0;
    public Text moneyText;
    public static Coin_Manager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("coin"))
        {
            coin = PlayerPrefs.GetInt("coin");
        }
    }
    private void Update()
    {
        moneyText.text =coin.ToString() ;
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("coin", coin);
    }
}
