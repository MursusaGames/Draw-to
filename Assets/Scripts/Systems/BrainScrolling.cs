using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrainScrolling : MonoBehaviour
{
    [Range(1, 10)]
    [Header("Contollers")]
    private int panCount;
    [Range(0, 700)]
    public int panSpace;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Header("Other Objects")]
    public List<GameObject> panPrefab;
    [SerializeField]  private MatchData data;
    //[SerializeField]  TextMeshProUGUI bayBtnText;
    //[SerializeField] TextMeshProUGUI subscribeText;
    //[SerializeField]  Image buyBtnImage;
    [SerializeField] private List<GameObject> herous;
    public GameObject[] instPans;
    Vector2[] panPos;
    Vector2[] panScale;
    Vector2 contentVector;

    RectTransform contentRect;
    int selectedPanID;
    public bool isScrolling;
    public string buyBtnTitle = "BUY";
    private float middleScrollVelosity = 1000f;
    private float multIndex = 10f;
    private float minSizeClamp = 0.5f;
    private float maxSizeClamp = 1f;
    public ScrollRect scrollRect;
    //[SerializeField] GameObject brainPrefab;
    //[SerializeField] GameObject swipeHand;
   

    private void OnEnable()
    {
        panCount = 5;//System.Enum.GetValues(typeof(SkinType)).Length;       
        panScale = new Vector2[panCount];
        contentRect = GetComponent<RectTransform>();
        panPos = new Vector2[panCount];
        instPans = new GameObject[panCount];

        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = panPrefab[i];
            //instPans[i].GetComponentInChildren<Image>().sprite = customSystem.customsSprites[i];            
            if (i == 0) continue;

            var tmpX = instPans[i - 1].transform.localPosition.x + panPrefab[i].GetComponent<RectTransform>().sizeDelta.x/2 + panSpace;
            instPans[i].transform.localPosition = new Vector2(tmpX, instPans[i].transform.localPosition.y);
            panPos[i] = -instPans[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        /*if(isScrolling && !PlayerPrefs.HasKey("SwipeHelp"))
        {
            PlayerPrefs.SetString("SwipeHelp", "Used");
            swipeHand.SetActive(false);
        }*/

        if (!isScrolling && (contentRect.anchoredPosition.x >= panPos[0].x || contentRect.anchoredPosition.x <= panPos[panPos.Length - 1].x))
        {
            scrollRect.inertia = false;
        }
            

        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - panPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
            }            

            float scale = Mathf.Clamp(1 / (distance / panSpace) * scaleOffset, minSizeClamp, maxSizeClamp);
            panScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, multIndex * Time.fixedDeltaTime);
            panScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, multIndex * Time.fixedDeltaTime);
            instPans[i].transform.localScale = panScale[i];
        }

        float scrollVelosity = Mathf.Abs(scrollRect.velocity.x);

        if (scrollVelosity < middleScrollVelosity && !isScrolling)
            scrollRect.inertia = false;

        if (isScrolling || scrollVelosity > middleScrollVelosity)
            return;

        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, panPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
        UpgradePanel();
    }

    public void UpgradePanel()
    {
        if (0 <= selectedPanID && 5 >= selectedPanID)
        {
            for (int i = 0; i < 5; i++)
            {
                if(i == selectedPanID)
                {
                    herous[i].SetActive(true);
                }
                else
                {
                    herous[i].SetActive(false);
                }
            }
            
            //subscribeText.text = customSystem.customsSubscribe[selectedPanID];
            /*if (selectedPanID == data.currentSkin)
            {
                bayBtnText.text = "USED";
                buyBtnImage.color = Color.green;
                buyBtnImage.gameObject.GetComponent<Button>().interactable = false;                
            }
            

            buyBtnImage.color = Color.yellow;
            buyBtnImage.gameObject.GetComponent<Button>().interactable = true;

            bayBtnText.text = PlayerPrefs.HasKey("PlayerSprites") && 1 == PlayerPrefs.GetInt("id" + selectedPanID.ToString()) ||
                PlayerPrefs.HasKey("PlayerSprites") && 0 == selectedPanID ? "CHOICE" : buyBtnTitle;  */          
        }
        else
            Debug.Log("Number out of range");
    }

    public void Scroll(bool scroll)
    {
        isScrolling = scroll;

        if (scroll)
            scrollRect.inertia = true;
    }
    public void BayCustom()
    {
        //customSystem.BayCustom(selectedPanID);
    }

}
