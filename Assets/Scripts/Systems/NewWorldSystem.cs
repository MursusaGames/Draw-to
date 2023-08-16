using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewWorldSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private Image filledImg;
    [SerializeField] private TextMeshProUGUI procent;
    private float divRange;
    private float progress;
    void OnEnable()
    {
        float score = data.score;
        if(data.avalableSkin == 0)
        {
            divRange = 200f;
            progress = score / divRange;
            if (progress > 1)
            {
                progress = 1f;
            }
        }
        else if(data.avalableSkin == 1)
        {
            divRange = 500f;
            progress = score / divRange;
        }
        CheckProgress();
    }

    public void CheckProgress()
    {
        filledImg.fillAmount = progress;
        procent.text = (progress * 100f).ToString("0")+"%";
    }
}
