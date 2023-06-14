using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Use_Item_Manager : MonoBehaviour
{
    public List<ItemAndButtonPair> itemAndButtonPairs;
    protected GameObject[] ListPlayer;
    protected GameObject Player;

    void Start()
    {
        ListPlayer = GameObject.FindGameObjectsWithTag("Player");

        if (ListPlayer.Count() != 0)
        {
            Player = ListPlayer[0];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            UseObject(itemAndButtonPairs[0].itemData);
        }
        GetTextInBtn(itemAndButtonPairs[0].button).text = itemAndButtonPairs[0].itemData.Quantity.ToString();
        GetTextInBtn(itemAndButtonPairs[1].button).text = itemAndButtonPairs[1].itemData.Quantity.ToString();
    }
    public void UseItemBoom()
    {
        UseObject(itemAndButtonPairs[0].itemData);
    }
    public void UseItemLightning()
    {
        UseObject(itemAndButtonPairs[1].itemData);
    }

    protected void UseObject(ItemData item)
    {
        if (Player != null)
        {
            if (item.Quantity > 0)
            {
                Vector2 playerPos = Player.transform.position;
                Vector2 playerForward = Player.transform.right;
                Vector2 objectPos = playerPos - playerForward.normalized * 0.7f;
                GameObject newObject = Instantiate(item.PrefabItem, objectPos, Quaternion.identity);

                item.decreaseQuantity(1);
            }
            else
            {
                Debug.Log("Out Of Stock item");
            }
        }
    }

    protected Text GetTextInBtn(Button btn)
    {
        return btn.GetComponentInChildren<Text>();
    }









    //--------------//
    [System.Serializable]
    public class ItemAndButtonPair
    {
        public ItemData itemData;
        public Button button;
    }
}
