using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLogic : MonoBehaviour
{

    public static float timer;
    public static readonly int GameSceneIndex = 1;
    public static readonly int SplashSceneIndex = 0;
    public int CurrentSceneIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 3)
        {
            LoadScene(GameSceneIndex);
            CurrentSceneIndex = GameSceneIndex;
            timer = 0;
        } else if (CurrentSceneIndex == 0)
            timer += Time.deltaTime;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
