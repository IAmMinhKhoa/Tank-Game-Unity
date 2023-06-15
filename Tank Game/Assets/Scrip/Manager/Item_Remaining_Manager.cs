using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Item_Remaining_Manager : MonoBehaviour
{




    public List<GameObject> ItemReamingParent;
    protected GameObject[] player;
    public List<Text> textCoolDownItem;
    public List<GameObject> textNotification;
    protected TankController TankController;
    // Start is called before the first frame update
    private void Awake()
    {
        LoadUIItem();
    }
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
     
        if (player.Count()!=0)
        {
            TankController = player[0].GetComponent<TankController>();
        }
    }
    protected  void LoadUIItem()
    {
        foreach (Transform child in transform)
        {
            ItemReamingParent.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        for (int i = 0; i < ItemReamingParent.Count(); i++)
        {
            textCoolDownItem.Add(ItemReamingParent[i].transform.GetChild(0).GetComponent<Text>());
            textNotification.Add(ItemReamingParent[i].transform.GetChild(2).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(TankController!=null)
            control_Ui_Item(TankController.isItemLightning, FindIndexItem("Item_Lightning"), TankController.timeRemainingItemLightning.ToString());
    }
    protected int FindIndexItem(string name)
    {
        int index = ItemReamingParent.FindIndex(gameObject => gameObject.name == name);
       
        if (index != -1)
        {
            // Game object ???c t�m th?y t?i v? tr� "index"
            return index;
        }
        else
        {
            // Kh�ng t�m th?y game object
            Debug.Log("erro find name Item ");
            return -1;
        }
    }
    void control_Ui_Item(int status,int index,string timeRemaining)
    {
        if (player.Count() != 0)
        {
            if (status != 0)
            {
                textCoolDownItem[index].transform.parent.gameObject.SetActive(true);
                textCoolDownItem[index].text = timeRemaining;
                if (status == 2)
                {
                    textNotification[index].SetActive(true);
                    
                }
            }

            else if (status == 0)
            {
                textCoolDownItem[index].transform.parent.gameObject.SetActive(false);
                textCoolDownItem[index].text = " ";
                textNotification[index].SetActive(false);
            }

        }
    }
    


}
