using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [Header("HealthBar color params")]
    public Color low;
    public Color high;

    [Header("HealthBar position params")]
    public Vector3 offset;

    [Header("References")]
    public Slider slider;

    public void SetHealth(float currentHealth, float maxHealth)
    {
        slider.gameObject.SetActive(currentHealth < maxHealth && currentHealth != 0);
        slider.value = currentHealth;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
