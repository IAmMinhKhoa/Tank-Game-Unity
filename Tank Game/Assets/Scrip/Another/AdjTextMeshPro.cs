using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AdjTextMeshPro : MonoBehaviour
{
    public TMP_Text myText;
    public float glowSpeed = 1f; // Tốc độ tăng/giảm của Glow Power
    public float maxGlow = 2f; // Chỉ số power tối đa
    public float minGlow = 0f; // Chỉ số power tối thiểu

    private float currentGlow = 0f; // Chỉ số power hiện tại
    private bool increase = true; // True nếu đang tăng giá trị, False nếu đang giảm giá trị

    void Awake()
    {
            Sound_Manager.instance.PlaySound(SoundType.BackGround_GameOver);
            Sound_Manager.instance.StopSound(SoundType.BackGround);
    }
    void Start()
    {
        currentGlow = myText.fontSharedMaterial.GetFloat("_GlowPower");
    }

    void Update()
    {
        // Tăng hoặc giảm giá trị của Glow Power
        if (increase)
        {
            currentGlow += glowSpeed * Time.deltaTime;
            if (currentGlow >= maxGlow)
            {
                increase = false;
            }
        }
        else
        {
            currentGlow -= glowSpeed * Time.deltaTime;
            if (currentGlow <= minGlow)
            {
                increase = true;
            }
        }

        // Cập nhật giá trị của vật liệu để áp dụng Glow
        myText.fontSharedMaterial.SetFloat("_GlowPower", currentGlow);
    }
}
