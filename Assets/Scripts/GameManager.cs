using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float timer;
    public string currentActiveScene = "SplashAnimation";

    void Start()
    {
        LoadScene(currentActiveScene);
        DontDestroyOnLoad(gameObject);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentActiveScene)
        {
            case "StartUpScene":
                if (timer >= 1.0f)
                {
                    timer = 0;
                    currentActiveScene = "SplashAnimation";
                    LoadScene(currentActiveScene);
                }
                break;
            case "SplashAnimation":
                if (timer >= 3.0f)
                {
                    timer = 0;
                    currentActiveScene = "MainGameScene";
                    LoadScene(currentActiveScene);
                }
                break;
            case "MainGameScene":
                break;
        }
        timer += Time.deltaTime;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
