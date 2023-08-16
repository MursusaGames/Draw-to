using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private Image img;
    private bool isBlink;
    private float count = 1f;
    private bool blinked;
    void OnEnable()
    {
        Blink();
    }
    private void Blink()
    {
        isBlink = true;
    }
    
    void Update()
    {
        if (isBlink)
        {
            count -= Time.deltaTime;
            if(count < 0)
            {
                count = 1f;
                img.enabled = blinked;
                blinked = !blinked;
            }
        }
    }
}
