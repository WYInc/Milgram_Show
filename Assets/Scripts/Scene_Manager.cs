using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    //Scene Main = SceneManager.GetSceneByBuildIndex(1);
    public void NextScene()
    {
        StartCoroutine(delayGameStart());
        
    }

    IEnumerator delayGameStart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }

    public void endGame()
    {
        Application.Quit();
        
    }

}
