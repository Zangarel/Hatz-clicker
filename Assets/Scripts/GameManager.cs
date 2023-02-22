using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float timer;
    public string currentActiveScene = "SplashAnimation";
    public bool Loaded = false;
    public double difference;
    public double HatzCount;
    public double HatzToAdd;

    void Start()
    {
        /* Incarca scena de start si pastreaza scena in care se incarca GameManager
         */
        LoadGame();
        LoadScene(currentActiveScene);
        DontDestroyOnLoad(gameObject);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentActiveScene)
        {
            /* Schimba scena dupa ce se termina animatia din scena SplashAnimation
             */
            case "SplashAnimation":
                if (timer >= 3.0f)
                {
                    timer = 0;
                    currentActiveScene = "MainGameScene";
                    LoadScene(currentActiveScene);
                }
                break;
            case "MainGameScene":
                if (!Loaded)
                {
                    HatzCount = double.Parse(PlayerPrefs.GetString("HatzCount"));
                    HatzToAdd = GameObject.FindWithTag("MainBuildingsLogicTag").GetComponent<MainBuildingsLogic>().tickBuildings();
                    GameObject.FindWithTag("MainLogicTag").GetComponent<MainLogicScript>().SetHatzCount(HatzCount + HatzToAdd * difference);
                    Loaded = true;
                }
                break;
        }
        timer += Time.deltaTime;
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void LoadScene(string sceneName)
    {
        /* Incarca o scena anume
         */
        SceneManager.LoadScene(sceneName);
    }

    private void SaveGame()
    {
        DateTime now = DateTime.Now;
        string HatzCount = GameObject.FindWithTag("MainLogicTag").GetComponent<MainLogicScript>().GetHatzCount().ToString();
        Debug.Log("SAVEGAME " + HatzCount);
        PlayerPrefs.SetString("HatzCount", HatzCount);
        PlayerPrefs.SetString("DateTime", now.ToBinary().ToString());
        
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        DateTime now = DateTime.Now;
        DateTime old;
        if (PlayerPrefs.HasKey("HatzCount"))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString("DateTime"));
            old = DateTime.FromBinary(temp);
            TimeSpan difference = now.Subtract(old);
            this.difference = difference.TotalSeconds;

        }
    }
}
