using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private GameObject firstWorldKeys;
    [SerializeField] private GameObject secondWorldKeys;
    [SerializeField] private GameObject threeWorldKeys;

    void OnEnable()
    {
        switch (data.avalableSkin)
        {
            case 0:
                firstWorldKeys.SetActive(true);
                secondWorldKeys.SetActive(false);
                threeWorldKeys.SetActive(false);
                break;
            case 1:
                firstWorldKeys.SetActive(false);
                secondWorldKeys.SetActive(true);
                threeWorldKeys.SetActive(false);
                break;
            case 2:
                firstWorldKeys.SetActive(false);
                secondWorldKeys.SetActive(false);
                threeWorldKeys.SetActive(true);
                break;

                default:
                firstWorldKeys.SetActive(false);
                secondWorldKeys.SetActive(false);
                threeWorldKeys.SetActive(true);
                break;
        }
    }
    
}
