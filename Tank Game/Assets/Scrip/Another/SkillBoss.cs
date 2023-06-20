using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkillBoss : MonoBehaviour
{
    //lam mo sprite di va tat collider
    public GameObject parent_Sprite;
    public Collider2D col_Tank;
    public TMP_Text text;
    public float CDSkill;
    public float timeSkilling;
    protected SpriteRenderer[] sprites;
    void Start()
    {
        // L?y t?t c? c�c SpriteRenderer trong object cha
        sprites = parent_Sprite.GetComponentsInChildren<SpriteRenderer>();
        StartCoroutine(RepeatSkill(CDSkill));
    }
   

    void TurnOnSkill()
    {
        text.enabled = true;
        foreach (SpriteRenderer sprite in sprites)
        {
            Color color = sprite.color;
            color.a = 0.2f;
            sprite.color = color;
        }
        col_Tank.enabled = false;
        StartCoroutine(StopSkillTime(timeSkilling));
    }
    void TurnOffSkill()
    {
        text.enabled = false;
        foreach (SpriteRenderer sprite in sprites)
        {
            Color color = sprite.color;
            color.a = 100f;
            sprite.color = color;
        }
        col_Tank.enabled = true;
    }
    IEnumerator RepeatSkill(float time)
    {
        while (true)
        {
            // G?i h�m m� b?n mu?n l?p l?i t?i ?�y
            TurnOnSkill();
            // Ch? 5 gi�y tr??c khi ti?p t?c l?p l?i h�m
            yield return new WaitForSeconds(time);

        }
    }
    IEnumerator StopSkillTime(float time)
    {
        yield return new WaitForSeconds(time);
        TurnOffSkill();
    }
}
