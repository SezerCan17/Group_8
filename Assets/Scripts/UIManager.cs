using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image satisfactionBarImage; 
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private Image economyBarImage;
    
    

    public void SatisfactionBar(int satisfaction)
    {
        
        float fillAmount = Mathf.Clamp01(satisfaction / 100f);
        satisfactionBarImage.fillAmount = fillAmount;
    }

    public void CoinUIText(int coin)
    {
        coinText.text = coin.ToString();
    }

    public void EconomyBar(int economy)
    {
        
        float fillAmount = Mathf.Clamp01(economy / 100f);
        economyBarImage.fillAmount = fillAmount;
    }



}
