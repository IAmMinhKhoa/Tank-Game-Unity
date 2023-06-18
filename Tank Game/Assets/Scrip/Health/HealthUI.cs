using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private GameObject AddHealtTextPrefab;
    // Prefab ch?a TextMeshPro ?? hi?n th? sát th??ng
    [SerializeField] private Transform damageTextParent; // L?u tr? parent c?a các hi?u ?ng sát th??ng
    [SerializeField] private Transform AddHealtTextParent;
    private void Start()
    {
        health.OnHealthChanged += UpdateHealthUI;
        health.OnDamageTaken += ShowDamageText;
        health.OnAddHealt += ShowAddHealtText;
        UpdateHealthUI(health.currentHealth ,health.maxHealth);
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.OnHealthChanged -= UpdateHealthUI;
            health.OnDamageTaken -= ShowDamageText;
            health.OnAddHealt -= ShowAddHealtText;
        }
       
    }

    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
    private void ShowDamageText(int damageAmount)
    {
       
        // T?o m?t ??i t??ng m?i t? prefab
        GameObject damageTextInstance = Instantiate(damageTextPrefab, damageTextParent);

        // Thi?t l?p v? trí hi?n th? tùy ch?nh
        damageTextInstance.transform.localPosition = Vector3.zero;

        // C?p nh?t giá tr? sát th??ng
        TextMeshProUGUI damageText = damageTextInstance.GetComponent<TextMeshProUGUI>();
        damageText.text = $"-{damageAmount} HP";
      
        // H?y ??i t??ng sau m?t kho?ng th?i gian nh?t ??nh
        Destroy(damageTextInstance, 1.0f);
    }

    private void ShowAddHealtText(int healt)
    {

        // T?o m?t ??i t??ng m?i t? prefab
        GameObject damageTextInstance = Instantiate(AddHealtTextPrefab, AddHealtTextParent);

        // Thi?t l?p v? trí hi?n th? tùy ch?nh
        damageTextInstance.transform.localPosition = Vector3.zero;

        // C?p nh?t giá tr? sát th??ng
        TextMeshProUGUI damageText = damageTextInstance.GetComponent<TextMeshProUGUI>();
        damageText.text = $"+{healt} HP";

        // H?y ??i t??ng sau m?t kho?ng th?i gian nh?t ??nh
        Destroy(damageTextInstance, 1.0f);
    }
 

}
