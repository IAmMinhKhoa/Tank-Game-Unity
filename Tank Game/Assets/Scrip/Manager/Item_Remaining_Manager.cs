using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Item_Remaining_Manager : MonoBehaviour
{
    public GameObject itemParent;
    public GameObject[] player;
    protected  Text textCoolDownItem;
    protected GameObject textNotification;
    protected TankController TankController;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectsWithTag("Player");
     
        if (player.Count()!=0)
        {
            TankController = player[0].GetComponent<TankController>();
        }
        textCoolDownItem = itemParent.transform.GetChild(0).GetComponent<Text>();
        textNotification = itemParent.transform.GetChild(2).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if(player.Count() != 0)
        {
            if (TankController.isItemLightning!=0)
            {
                textCoolDownItem.transform.parent.gameObject.SetActive(true);
                textCoolDownItem.text = TankController.timeRemainingItemLightning.ToString();
                if (TankController.isItemLightning == 2)
                {
                    textNotification.SetActive(true);
                }
            }

            else if(TankController.isItemLightning==0)
            {
                textCoolDownItem.transform.parent.gameObject.SetActive(false);
                textCoolDownItem.text = " ";
                textNotification.SetActive(false    );
            }
          
        }        
    }

    


}
