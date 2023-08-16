using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private UISystem uISystem;
    [SerializeField] private MatchData data;
    [SerializeField] private GameObject noGoldWindow;
    [SerializeField] private GameObject buyKeysWindow;
    [SerializeField] private GameObject buyGoldWindow;
    [SerializeField] private GameObject noPaymentWindow;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private int oneKeyCost;
    [SerializeField] private int threeKeyCost;
    [SerializeField] private int sevnKeyCost;
    

    public void ShowShopMenu()
    {
        shopMenu.SetActive(true);
    }
    public void HideShopMenu()
    {
        shopMenu.SetActive(false);
    }
    public void BuyGold(int count)
    {
        if (count == oneKeyCost)
        {
            data.score += oneKeyCost;            
            PlayerPrefs.SetInt("Score", data.score);
            uISystem.ChangeUI();
            buyGoldWindow.SetActive(true);
        }
        else if (count == threeKeyCost)
        {
            data.score += threeKeyCost;
            PlayerPrefs.SetInt("Score", data.score);
            uISystem.ChangeUI();
            buyGoldWindow.SetActive(true);
        }
        else if (count == sevnKeyCost)
        {
            data.score += sevnKeyCost;
            PlayerPrefs.SetInt("Score", data.score);
            uISystem.ChangeUI();
            buyGoldWindow.SetActive(true);
        }
    }
    public void HideBuyKeyWindow()
    {
        buyKeysWindow.SetActive(false);
    }
    public void HideNoGoldWindow()
    {
        noGoldWindow.SetActive(false);
    }
    public void BuyKeys(int count)
    {
        if(count == oneKeyCost)
        {
            if (data.score > oneKeyCost)
            {
                data.score -= oneKeyCost;
                data.keys++;
                PlayerPrefs.SetInt("Keys", data.keys);
                PlayerPrefs.SetInt("Score", data.score);
                uISystem.ChangeUI();
                buyKeysWindow.SetActive(true);
            }
            else
            {
                noGoldWindow.SetActive(true);
            }
        }
        else if(count == threeKeyCost)
        {
            if (data.score > threeKeyCost)
            {
                data.score -= threeKeyCost;
                data.keys++;
                PlayerPrefs.SetInt("Keys", data.keys);
                PlayerPrefs.SetInt("Score", data.score);
                buyKeysWindow.SetActive(true);
            }
            else
            {
                noGoldWindow.SetActive(true);
            }
        }
        else if(count == sevnKeyCost)
        {
            if (data.score > sevnKeyCost)
            {
                data.score -= sevnKeyCost;
                data.keys++;
                PlayerPrefs.SetInt("Keys", data.keys);
                PlayerPrefs.SetInt("Score", data.score);
                buyKeysWindow.SetActive(true);
            }
            else
            {
                noGoldWindow.SetActive(true);
            }
        }
    }
    public void BuyOffer()
    {
        data.score += oneKeyCost;
        buyGoldWindow.SetActive(true);
        data.keys += 3;
        buyKeysWindow.SetActive(true);
        data.noAds = 1;
        PlayerPrefs.SetInt("NoAds", 1);
        PlayerPrefs.SetInt("Keys", data.keys);
        PlayerPrefs.SetInt("Score", data.score);
    }
    public void NoPayment()
    {
        noPaymentWindow.SetActive(true);
    }
    public void HideNoPayment()
    {
        noPaymentWindow.SetActive(false);
    }
}
