using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject info;
    public GameObject transition;
    public void Start()
    {
        info.SetActive(false);
        transition.SetActive(false);
    }

    /*public void LoadGame()
    {
        transition.SetActive(true);
        
        SceneManager.LoadScene(1);
        
    }*/
    public void LoadGame()
    {

        //LoadTransition();
        StartCoroutine("LoadTransition");
        

    }

    IEnumerator LoadTransition()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public void infoBox(bool active)
    {
        info.SetActive(active);
        
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


}
