using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class SkinsBtns : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private List<Image> btnsImgs;
    [SerializeField] private List<GameObject> keys;
    [SerializeField] private List<TextMeshProUGUI> btnsTexts;
    public List<int> _openSkins;

    private void OnEnable()
    {
        SetBtn(data.currentSkin, _openSkins);
    }
    public void SetBtn(int index, List<int> openSkins)
    {
        for (int i = 0; i < openSkins.Count; i++)
        {
            if (openSkins[i] == index)
            { 
                btnsImgs[index].color = Color.green;
                btnsTexts[index].gameObject.SetActive(true);
                btnsTexts[index].text = "Used";
                keys[index].gameObject.SetActive(false);
            }
            else
            {
                btnsImgs[openSkins[i]].color = Color.yellow;
                btnsTexts[openSkins[i]].gameObject.SetActive(true);
                btnsTexts[openSkins[i]].text = "Choose";
                keys[openSkins[i]].gameObject.SetActive(false);
            }
        }

    }
}
