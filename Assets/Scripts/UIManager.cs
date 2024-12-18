using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image satisfactionBarImage; // Doluluk barı için image
    

    public void SatisfactionBar(int satisfaction)
    {
        // Doluluk oranını hesapla (0 ile 1 arasında olmalı)
        float fillAmount = Mathf.Clamp01(satisfaction / 100f);
        satisfactionBarImage.fillAmount = fillAmount;

    }
}
