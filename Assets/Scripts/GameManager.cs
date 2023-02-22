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
    public ulong HatzCount;
    public ulong HatzToAdd;
    public string loadedBuildingsMetaData;

    void Start()
    {
        /* Incarca scena de start si pastreaza scena in care se incarca GameManager
         */
        LoadScene(currentActiveScene);
        LoadGame();
        DontDestroyOnLoad(gameObject);
        timer = 0f;
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
                    timer = 0f;
                    currentActiveScene = "MainGameScene";
                    LoadScene(currentActiveScene);
                }
                break;
            case "MainGameScene":
                if (!Loaded)
                {
                    HatzCount = ulong.Parse(PlayerPrefs.GetString("HatzCount"));
                    GameObject.FindWithTag("MainBuildingsLogicTag").GetComponent<MainBuildingsLogic>().loadSaveDataFromString(loadedBuildingsMetaData);
                    HatzToAdd = GameObject.FindWithTag("MainBuildingsLogicTag").GetComponent<MainBuildingsLogic>().tickBuildings();
                    GameObject.FindWithTag("MainLogicTag").GetComponent<MainLogicScript>().SetHatzCount((ulong)(HatzCount + HatzToAdd * difference));
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
        PlayerPrefs.SetString("BuildingsSaveData", GameObject.FindWithTag("MainBuildingsLogicTag").GetComponent<MainBuildingsLogic>().getAllBuildingsMetaData());
        Debug.Log(GameObject.FindWithTag("MainBuildingsLogicTag").GetComponent<MainBuildingsLogic>().getAllBuildingsMetaData());
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
        if (PlayerPrefs.HasKey("BuildingsSaveData"))
        {
            loadedBuildingsMetaData = PlayerPrefs.GetString("BuildingsSaveData");
        }
        else
        {
            loadedBuildingsMetaData = GameObject.FindWithTag("MainBuildingsLogicTag").GetComponent<MainBuildingsLogic>().getAllBuildingsMetaData();
        }
    }
}
