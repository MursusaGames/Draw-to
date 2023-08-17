using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using GameAnalyticsSDK;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private SaveDataSystem saveDataSystem;
    private int dateNow;
    public void LoadScene()
    {
        SceneManager.LoadScene(data.level);
    }
    private void Start()
    {
        dateNow = DateTime.Now.DayOfYear;
        GameAnalytics.Initialize();
        if (data.startGame)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            fields.Add("Day", data.daysCount);
            GameAnalytics.NewDesignEvent("main_menu", fields);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Day", data.daysCount);
            AppMetrica.Instance.ReportEvent("main_menu", parameters);            
        }
        else
        {
            CheckDay();
            data.sessionCount++;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Session", data.sessionCount);
            parameters.Add("Day", data.daysCount);
            AppMetrica.Instance.ReportEvent("game_start", parameters);
            AppMetrica.Instance.ReportEvent("main_menu", parameters);
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
        if(PlayerPrefs.GetInt("date",0) == dateNow)
        {
            return;
        }
        else
        {
            data.daysCount++;
            PlayerPrefs.SetInt("date",dateNow);
        }
        
    }
    private void OnApplicationQuit()
    {
        data.startGame = false;
    }
}
