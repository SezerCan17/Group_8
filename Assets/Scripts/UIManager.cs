using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image satisfactionBarImage; 
    [SerializeField] private TMP_Text deneme;
    

    public void SatisfactionBar(int satisfaction)
    {
        
        float fillAmount = Mathf.Clamp01(satisfaction / 100f);
        satisfactionBarImage.fillAmount = fillAmount;

        deneme.text = satisfaction.ToString();

    }
}
