using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSet : MonoBehaviour
{
    [Range(0f, 20f)]
    public float snapSpeed;
    [SerializeField] private List<float> panelCenters;
    [SerializeField] private float panelWidth;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private List<GameObject> heroes;
    Vector2 contentVector;
    public bool isScrolling;
    private int selectedPanID;
    public ScrollRect scrollRect;
    void Update()
    {
        if (isScrolling) return;
        for (int i = 0; i < panelCenters.Count; i++)
        {
            if((rectTransform.position.x - panelCenters[i]) < panelWidth)
            {
                selectedPanID = i;
                continue;
            }
        }
        contentVector.x = Mathf.SmoothStep(rectTransform.anchoredPosition.x, panelCenters[selectedPanID], snapSpeed * Time.deltaTime);
        rectTransform.anchoredPosition = contentVector;
        for (int i = 0; i < 5; i++)
        {

        }
    }
    public void Scroll(bool scroll)
    {
        isScrolling = scroll;

        if (scroll)
            scrollRect.inertia = true;
    }
}
