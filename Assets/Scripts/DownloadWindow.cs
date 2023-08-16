using UnityEngine;
using UnityEngine.UI;


public class DownloadWindow : MonoBehaviour
{
    [SerializeField] private float downloadTime;
    [SerializeField] private Image bar;
    [SerializeField] private SkinDownload skinDownload;
    public float count;
    private bool startCount;
    private void OnEnable()
    {
        count = 0;
        startCount = true;
    }

    void Update()
    {
        if (startCount)
        {
            count += Time.deltaTime;
            bar.fillAmount =  count/downloadTime;
            if (count >= downloadTime)
            {
                skinDownload.ShowHerous();
                startCount = false;
                gameObject.SetActive(false);
            }
        }
        
    }
}
