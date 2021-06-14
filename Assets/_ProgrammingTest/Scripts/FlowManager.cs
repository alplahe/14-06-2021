using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneToLoad
{
  Init,
  Menu,
  InGame
}

public class FlowManager : MonoBehaviour
{
  public SceneToLoad sceneToLoad;

  #region Singleton
  private static FlowManager instance;

  public static FlowManager Instance 
  { 
    get 
    { 
      return instance; 
    } 
  }

  void Awake()
  {
    if (instance != null && instance != this)
    {
      Debug.Log("Destroy duplicated FlowManager instance");
      Destroy(this.gameObject);
    }
    else
    {
      Debug.Log("Creating FlowManager instance");
      instance = this;
      DontDestroyOnLoad(instance);
    }
  }
  #endregion

  void Start()
  {
    GotoMenu();
  }

  void GotoInit()
  {
    sceneToLoad = SceneToLoad.Init;
    LoadLoadingScreenScene();
  }

  void GotoMenu()
  {
    sceneToLoad = SceneToLoad.Menu;
    LoadLoadingScreenScene();
  }

  void GotoInGame()
  {
    sceneToLoad = SceneToLoad.InGame;
    LoadLoadingScreenScene();
  }

  void LoadLoadingScreenScene()
  {
    Debug.Log("LoadLoadingScreenScene");
    SceneManager.LoadScene("LoadingScreen");
  }
}
