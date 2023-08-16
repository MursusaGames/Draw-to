using UnityEngine;
using TMPro;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldUi;
    [SerializeField] private TextMeshProUGUI goldWindow;
    [SerializeField] private MatchData data;
    [SerializeField] private float delay;
    [SerializeField] private LevelController levelController;
    [SerializeField] private GameObject moneyWindow;
    [SerializeField] private AudioSource audioSource;
    private bool startIncrease;
    private int gold;
    private float _delay;
    void OnEnable()
    {
        _delay = delay;
        gold = levelController.levelScore;
        goldWindow.text = ("+"+gold.ToString());        
        moneyWindow.SetActive(true);
        Invoke(nameof(GoCount), 1f);
    }

    private void GoCount()
    {
        startIncrease = true;
    }
    void Update()
    {
        if (startIncrease)
        {
            _delay -= Time.deltaTime;
            if (_delay <= 0)
            {
                gold--;
                if(gold < 0)
                {
                    startIncrease = false;
                    moneyWindow.SetActive(false);
                    return;
                }
                goldWindow.text = ("+" + gold.ToString());
                if (data.isSound)
                {
                    audioSource.Play();
                }                
                goldUi.text = (data.score - gold).ToString();
                _delay = delay;
            }           

        }
    }
}
