using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
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

  void Start()
  {
    GotoMenu();
  }

  void GotoInit()
  {
    // TODO: Load Init Scene
  }

  void GotoMenu()
  {
    // TODO: Load Menu Scene
  }

  void GotoInGame()
  {
    // TODO: Load InGame Scene
  }
}
