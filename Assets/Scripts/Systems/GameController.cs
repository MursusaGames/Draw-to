using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using GameAnalyticsSDK;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private SaveDataSystem saveDataSystem;
    private string dateNow;
    public void LoadScene()
    {
        SceneManager.LoadScene(data.level);
    }
    private void Start()
    {
        dateNow = DateTime.Now.DayOfYear.ToString();
        Debug.Log(dateNow);
        if (data.startGame)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("Day", data.daysCount);
            GameAnalytics.NewDesignEvent("main_menu", fields);
            AppMetrica.Instance.ReportEvent("main_menu", " Day " + data.daysCount.ToString());            
        }
        else
        {
            CheckDay();
            data.sessionCount++;
            AppMetrica.Instance.ReportEvent("game_start", "Sessions " + data.sessionCount.ToString() + " Days " + data.daysCount.ToString());
            AppMetrica.Instance.ReportEvent("main_menu", " Days " + data.daysCount.ToString());
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("Session", data.sessionCount);
            fields.Add("Day", data.daysCount);
            GameAnalytics.NewDesignEvent("main_menu", fields);
            GameAnalytics.NewDesignEvent("game_start", fields);
            GameAnalytics.StartSession();
            data.startGame = true;            
        }
        saveDataSystem.SaveSession();
    }
    private void CheckDay()
    {
        if(PlayerPrefs.GetString("date","0") == dateNow)
        {
            return;
        }
        else
        {
            data.daysCount++;
            PlayerPrefs.SetString("date",dateNow);
        }
        
    }
    private void OnApplicationQuit()
    {
        data.startGame = false;
    }
}
