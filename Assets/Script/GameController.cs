using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public static GameController instance;
    //private void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;    
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
           
    //    }
    //}
    public void GameHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameStart()
    {
        
        SceneManager.LoadScene("GameScreen");
    }

}
