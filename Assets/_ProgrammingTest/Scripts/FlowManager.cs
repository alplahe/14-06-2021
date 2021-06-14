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
  SceneToLoad sceneToLoad;

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
    // TODO: Load Init Scene
    sceneToLoad = SceneToLoad.Init;
    SceneManager.LoadScene("LoadingScreen");
  }

  void GotoMenu()
  {
    // TODO: Load Menu Scene
    sceneToLoad = SceneToLoad.Menu;
    SceneManager.LoadScene("LoadingScreen");
  }

  void GotoInGame()
  {
    // TODO: Load InGame Scene
    sceneToLoad = SceneToLoad.InGame;
    SceneManager.LoadScene("LoadingScreen");
  }
}
