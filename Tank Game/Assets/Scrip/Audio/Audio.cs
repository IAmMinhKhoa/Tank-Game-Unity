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
    protected bool isMute = false;
    private void Start()
    {
        imgBtn =GetComponent<Image>();
    }
    public void OnOffAudio()
    {
        click();
        if (isMute == false)
        {
            Sound_Manager.PauseSound();
            imgBtn.sprite=sprite_Mute;
        }
        if (isMute)
        {
            Sound_Manager.SetAllVolumesToOriginal();
            imgBtn.sprite=sprite_UnMute;    
        }
        isMute = !isMute;
        
    }
    public void click()
    {
        Sound_Manager.instance.PlaySound(SoundType.Click);
    }

}
