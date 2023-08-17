using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using GameAnalyticsSDK;


public class LevelController : MonoBehaviour
{
    private Animator animM;
    private Animator animW;
    [SerializeField] private Image doorImg;
    public int levelScore;
    [SerializeField] private int thisLevel;
    public int thisUserNumber;
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI keys;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private MatchData data;
    [SerializeField] private Man man;
    [SerializeField] private Man man2;
    [SerializeField] private Woman woman;
    [SerializeField] private DrawManager drawManager;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private GameObject helpWindow;
    [SerializeField] private TouchDetector touchDetector;
    [SerializeField] private GameObject fightPrefab;
    [SerializeField] private Transform fightParent;
    [SerializeField] private ParticleSystem konfety;
    [SerializeField] private List<Chucha> chuchas;
    
    public bool keyInGame;
    public bool isKey;
    private GameObject fightGO;
    private int winNumber;
    private bool isFight;
    public bool isChucha;
    private AudioClip currentRunClip;
    public bool help;

    private void OnEnable()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("Level", thisLevel);
        parameters.Add("Day", data.daysCount);
        AppMetrica.Instance.ReportEvent("level_start", parameters);
        AppMetrica.Instance.SendEventsBuffer();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level " + thisLevel.ToString() + ", day " + data.daysCount.ToString());
    }
    private void Start()
    {
        currentRunClip = data.soundDataContainer.sounds[data.currentSkin].clip;
        level.text = data.level.ToString();
        gold.text = data.score.ToString();
        keys.text = data.keys.ToString();
    }
    public void SetAnimators(Animator m, Animator w)
    {
        animM = m;
        animW = w;
    }
    private void OnApplicationQuit()
    {
        data.startGame = false;
    }
    public void Back()
    {
        touchDetector.stopPlay = true;
        SceneManager.LoadScene(0);
    }
    public void ShowHelpWindow()
    {
        helpWindow.SetActive(true);
    }
    public void HideHelpWindow()
    {
        help = false;
        helpWindow.SetActive(false);
    }
    
    
    
    public void GetKey()
    {
        isKey = true;
        doorImg.gameObject.SetActive(false);
    }
    public void Reload()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("Level", thisLevel);
        parameters.Add("Day", data.daysCount);
        AppMetrica.Instance.ReportEvent("level_restart", parameters);
        AppMetrica.Instance.SendEventsBuffer();
        
        data.level = thisLevel;
        touchDetector.isMan = false;
        touchDetector.isWoman = false;
        SceneManager.LoadScene(thisLevel);
    }
    public void NextLevelForAD()
    {
        data.level = thisLevel + 1;
        if (thisLevel == data.maxLevel)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(data.level);
    }
    public void NextLevel()
    {
        if(thisLevel == data.maxLevel) 
            SceneManager.LoadScene(1);
        else 
            SceneManager.LoadScene(thisLevel+1);
    }
    public void Win()
    {
        winNumber++;
        
        if(winNumber == thisUserNumber)
        {
            if (keyInGame && !isKey)
            {
                man.Boom();
                return;
            }
            drawManager.RemoveAllLine(thisUserNumber);
            touchDetector.stopPlay = true;
            Invoke(nameof(ShowWinWindow), 1f);
            data.level = thisLevel+1;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Level", thisLevel);
            parameters.Add("Day", data.daysCount);
            AppMetrica.Instance.ReportEvent("level_complete", parameters);
            AppMetrica.Instance.SendEventsBuffer();
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level " + thisLevel.ToString() + ", day " + data.daysCount.ToString());
            PlayerPrefs.SetInt("Level", thisLevel + 1);
            if (thisLevel== data.maxLevel)
            {
                data.level = 1;
                PlayerPrefs.SetInt("Level", 1);
            }   //TODO level restriction
                
            data.score += levelScore;
            PlayerPrefs.SetInt("Score", data.score);
        }
    }
    private void ShowWinWindow()
    {
        man.HideVisual();
        if (thisUserNumber == 2) 
            woman.HideVisual();
        if (thisUserNumber == 3) 
            man2.HideVisual();
        winWindow.SetActive(true);
        konfety.Play();
    }
    private void ShowLoseWindow()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("Level", thisLevel);
        parameters.Add("Day", data.daysCount);
        AppMetrica.Instance.ReportEvent("level_fail", parameters);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "level " + thisLevel.ToString() + ", day " + data.daysCount.ToString());
        if (thisUserNumber>1) 
            woman.HideVisual();        
        man.HideVisual();
        loseWindow.SetActive(true);
        if(fightGO != null)
            Destroy(fightGO);
    }
    public void Boom(bool mans)
    {
        if (data.isVibration) 
            Handheld.Vibrate();
        if (mans&& thisUserNumber>1)
        {
            woman.StopGame();
            woman.HideVisual();
        }
        if(!mans)
        {
            man.StopGame();
            man.HideVisual();
        } 
            
        touchDetector.stopPlay = true;
        drawManager.isDraw = false;
        drawManager.RemoveAllLine(thisUserNumber);
        Invoke(nameof(ShowLoseWindow), 1f);
    }
    public void Fight(Vector3 pos)
    {
        if (isFight) return;
        if (data.isVibration)
            Handheld.Vibrate();
        isFight = true;
        man.StopGame();
        man.HideVisual();
        woman.StopGame();
        woman.HideVisual();
        if(thisUserNumber == 3)
        {
            man2.StopGame();
            man2.HideVisual();
        } 
            
        drawManager.RemoveAllLine(thisUserNumber);
        touchDetector.stopPlay = true;
        fightGO = Instantiate(fightPrefab,pos,Quaternion.identity, fightParent);
        Invoke(nameof(ShowLoseWindow), 2f);
    }
    public void Go(int count)
    {
        if(count == 3)
        {
            man2.Go(drawManager.mans2Line.gameObject.GetComponent<LineRenderer>(), currentRunClip);
        }
        else if(count == 2)
        {
            woman.Go(drawManager.womansLine.gameObject.GetComponent<LineRenderer>(), currentRunClip);
            animW.SetBool("run", true);
        }
        man.Go(drawManager.mansLine.gameObject.GetComponent<LineRenderer>(), currentRunClip);
        animM.SetBool("run", true);
        if (isChucha)
        {
            foreach(var chucha in chuchas)
            {
                chucha.Go();
            }
        }
            
    }
}
