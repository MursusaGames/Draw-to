using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinDownload : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private MatchData data;
    [SerializeField] private LevelController levelController;
    [Header("Game Objects")]
    [SerializeField] private GameObject downloadWindow;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject hero2;
    [SerializeField] private GameObject hero3;
    [Header("Images")]
    [SerializeField] private Image sky;
    [SerializeField] private List<Image> chuchas;
    [SerializeField] private List<Image> avtos;
    [SerializeField] private List<Image> roads;
    [SerializeField] private List<Image> fences;
    [SerializeField] private List<Image> hunters;
    [SerializeField] private List<Image> walls;
    [SerializeField] private List<Image> minas;
    [SerializeField] private Image skyBG;    
    [SerializeField] private Image moon;
    [SerializeField] private Image earth;
    [SerializeField] private Image dekor;
    [SerializeField] private Image dekor1;
    [SerializeField] private Image dekor2;
    [SerializeField] private Image mansHoum;
    [SerializeField] private Image womansHoum;
    [SerializeField] private List<GameObject> skinsVisualM;
    [SerializeField] private List<GameObject> skinsVisualW;
    [SerializeField] private List<Animator> skinsAnimatorsM;
    [SerializeField] private List<Animator> skinsAnimatorsW;
    public Animator currentAnimatorM;
    public Animator currentAnimatorW;
    public bool isHunter;
    public bool isWall;
    public bool isMina;
    void Start()
    {
        InitSkins();
    }

    private void InitSkins()
    {
        downloadWindow.SetActive(true);
        hero.SetActive(false);
        if (levelController.thisUserNumber == 2)
        {
            hero2.SetActive(false);
        }
        if (levelController.thisUserNumber == 3)
        {
            hero2.SetActive(false);
            hero3.SetActive(false);
        }
        sky.sprite = data.skinDataContainer.skins[data.currentSkin].sky;
        if (isHunter)
        {
            foreach (var hunter in hunters)
            {
                hunter.sprite = data.skinDataContainer.skins[data.currentSkin].hunter;
            }
        }
        if (levelController.isChucha)
        {
            foreach (var chucha in chuchas)
            {
                chucha.sprite = data.skinDataContainer.skins[data.currentSkin].chucha;
            }
        }
        if (isMina)
        {
            foreach (var  mina in minas)
            {
                mina.sprite = data.skinDataContainer.skins[data.currentSkin].mina;
            }
        }
        if (isWall)
        {
            foreach (var wall in walls)
            {
                wall.sprite = data.skinDataContainer.skins[data.currentSkin].wall;
                if(data.currentSkin == 1)
                {
                    wall.gameObject.GetComponent<Animator>().enabled = true;
                }
            }
        }
        foreach (var road in roads)
        {
            road.sprite = data.skinDataContainer.skins[data.currentSkin].road;
        }
        foreach (var fence in fences)
        {
            fence.sprite = data.skinDataContainer.skins[data.currentSkin].fence;
        }

        foreach (var avto in avtos)
        {
            avto.sprite = data.skinDataContainer.skins[data.currentSkin].car;
        }
        skyBG.sprite = data.skinDataContainer.skins[data.currentSkin].skyBG;
        moon.sprite = data.skinDataContainer.skins[data.currentSkin].moon;
        earth.sprite = data.skinDataContainer.skins[data.currentSkin].earth;
        string htmlValue = data.skinDataContainer.skins[data.currentSkin].earthColor;
        Color newCol;
        if (ColorUtility.TryParseHtmlString(htmlValue, out newCol))
        {
            earth.color = newCol;
        }
        dekor.sprite = data.skinDataContainer.skins[data.currentSkin].dekor;
        dekor1.sprite = data.skinDataContainer.skins[data.currentSkin].dekor;
        dekor2.sprite = data.skinDataContainer.skins[data.currentSkin].dekor;
        mansHoum.sprite = data.skinDataContainer.skins[data.currentSkin].manHoum;
        womansHoum.sprite = data.skinDataContainer.skins[data.currentSkin].womanHoum;
        for (int i = 0; i < skinsVisualM.Count; i++)
        {
            if (i == data.currentSkin)
            {
                skinsVisualM[i].SetActive(true);
                if (levelController.thisUserNumber > 1) 
                    skinsVisualW[i].SetActive(true);
            }
            else
            {
                skinsVisualM[i].SetActive(false);
                if (levelController.thisUserNumber > 1) 
                    skinsVisualW[i].SetActive(false);
            }
        }
        currentAnimatorM = skinsAnimatorsM[data.currentSkin];
        if(levelController.thisUserNumber>1) 
            currentAnimatorW = skinsAnimatorsW[data.currentSkin];
        levelController.SetAnimators(currentAnimatorM, currentAnimatorW);
    }
     public void ShowHerous()
    {
        hero.SetActive(true);
        if (levelController.thisUserNumber == 2)
        {
            hero2.SetActive(true);
        }
        if (levelController.thisUserNumber == 3)
        {
            hero2.SetActive(true);
            hero3.SetActive(true);
        }
    }
}
