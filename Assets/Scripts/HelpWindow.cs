using TMPro;
using UnityEngine;

public class HelpWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI helpText;
    [SerializeField] private HelpData helpData;
    void OnEnable()
    {
        int rand = Random.Range(0, helpData.helpList.Count);
        helpText.text = helpData.helpList[rand];
    }
    
}
