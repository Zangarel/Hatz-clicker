using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    SceneLogic sceneLogic;
    // Start is called before the first frame update
    void Start()
    {
        sceneLogic = gameObject.AddComponent<SceneLogic>();
        sceneLogic.LoadScene(sceneIndex: SceneLogic.SplashSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
