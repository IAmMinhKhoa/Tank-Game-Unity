using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] protected Sound_Manager Sound_Manager;
    [SerializeField] protected Sprite sprite_Mute;
    [SerializeField] protected Sprite sprite_UnMute;
    protected Image imgBtn;
    protected int isMute;

    private void Start()
    {
        Sound_Manager = FindObjectOfType<Sound_Manager>();
        if (Sound_Manager == null)
        {
            Debug.Log("Error Find");
        }
        imgBtn =GetComponent<Image>();

     
        //set up sound default
        if (Sound_Manager.activeSound == true)
        {
            Sound_Manager.SetAllVolumesToOriginal();
            imgBtn.sprite = sprite_UnMute;
        }
        else
        {
            Sound_Manager.PauseSound();
            imgBtn.sprite = sprite_Mute;
        }
    }
   
    //when click button mute in setting
    public void OnOffAudio()
    {          
        click();
        if (Sound_Manager.activeSound==true)
        {
            Sound_Manager.PauseSound();
            imgBtn.sprite=sprite_Mute;
            Sound_Manager.activeSound=false;
        }
       else if (Sound_Manager.activeSound == false)
        {
            Sound_Manager.SetAllVolumesToOriginal();
            imgBtn.sprite=sprite_UnMute;
            Sound_Manager.activeSound = true;
           
        }
        


    }
    public void click()
    {
        Sound_Manager.instance.PlaySound(SoundType.Click);
    }

}
