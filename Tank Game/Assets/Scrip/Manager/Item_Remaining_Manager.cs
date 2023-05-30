using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Remaining_Manager : MonoBehaviour
{
    public Text textCooldown;
    public GameObject[] player;
    protected TankController TankController;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectsWithTag("Player");
        TankController = player[0].GetComponent<TankController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (TankController.isItemLightning)
        {
            textCooldown.transform.parent.gameObject.SetActive(true);
            textCooldown.text = TankController.timeRemainingItemLightning.ToString();
        }    
          
        else
        {
            textCooldown.transform.parent.gameObject.SetActive(false);
            textCooldown.text = " ";
        }    
            
    }
}
