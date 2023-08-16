using System.Collections.Generic;
using UnityEngine;

public class SkinSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private GameObject noKeyPopUp;
    [SerializeField] private SkinsBtns skinsBtns;
    [SerializeField] private UISystem uISystem;
    public List<int> openSkins = new List<int>();

    

    public void GetOpenSkins()
    {
        int count = data.avalableSkin;
        openSkins.Add(0);
        for (int i = 1; i <= count; i++)
        { 
            var index = PlayerPrefs.GetInt(i.ToString());
            openSkins.Add(index);
            skinsBtns._openSkins = openSkins;
        }
    }
    
    public void ChangeSkin(int index)
    {
        if (openSkins.Contains(index))
        {
            skinsBtns.SetBtn(index, openSkins);
        }
        else
        {
            if (data.keys > 0)
            {
                data.avalableSkin++;
                openSkins.Add(index);
                PlayerPrefs.SetInt("AvalableSkins", data.avalableSkin);
                PlayerPrefs.SetInt(data.avalableSkin.ToString(), index);
                skinsBtns.SetBtn(index, openSkins);
                data.keys -= 1;
                PlayerPrefs.SetInt("Keys", data.keys);
                uISystem.ChangeUI();
            }
            else
            {
                noKeyPopUp.SetActive(true);
                return;
            }
        }
        
        data.currentSkin = index;
        PlayerPrefs.SetInt("Skin", index);

    }

    public void HidePopUp()
    {
        noKeyPopUp.SetActive(false);
    }
}
