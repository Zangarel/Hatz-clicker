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
        /* Incarca scena de start si pastreaza scena in care se incarca GameManager
         */
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
                break;
        }
        timer += Time.deltaTime;
    }

    public void LoadScene(string sceneName)
    {
        /* Incarca o scena anume
         */
        SceneManager.LoadScene(sceneName);
    }
}
