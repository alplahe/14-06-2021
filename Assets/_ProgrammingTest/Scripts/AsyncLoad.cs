using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour
{
  int counter = 0;
  FlowManager flowManager;
  SceneToLoad sceneToLoad;

  private void Start()
  {
    Init();
  }

  public void Init()
  {
    FlowManager flowManager = FlowManager.Instance.GetComponent<FlowManager>();
    if(flowManager != null)
    {
      sceneToLoad = flowManager.sceneToLoad;
    }

    LoadScene();
  }

  private void Update()
  {
    ShowCounterInLog();
  }

  void ShowCounterInLog()
  {
    Debug.Log("Counter: " + counter);
    counter++;
  }

  void LoadScene()
  {
    if (!CheckScene(sceneToLoad.ToString())) return;

    GC.Collect();
    SceneManager.LoadSceneAsync(sceneToLoad.ToString());
  }

  bool CheckScene(string sceneName)
  {
    for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
    {
      if (sceneName == GetSceneNameFromBuildIndex(i))
        return true;
    }
    return false;
  }

  string GetSceneNameFromBuildIndex(int buildIndex)
  {
    string path = SceneUtility.GetScenePathByBuildIndex(buildIndex);
    int slash = path.LastIndexOf('/');
    string name = path.Substring(slash + 1);
    int dot = name.LastIndexOf('.');
    return name.Substring(0, dot);
  }
}
