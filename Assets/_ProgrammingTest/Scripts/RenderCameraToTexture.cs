using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderCameraToTexture : MonoBehaviour
{
  Camera renderCamera;
  public Texture texture;
  public Material material;
  public MeshRenderer meshRenderer;
  RenderTexture renderTexture;
  public RawImage rawImage;

  private void Start()
  {
    Init();
  }

  void Init()
  {
    renderCamera = GetComponent<Camera>();
    renderTexture = new RenderTexture(256, 256, 0);
        
    if (renderCamera == null) return;
    if (rawImage == null) return;

    //material = meshRenderer.materials[0];
    texture = rawImage.texture;
    CreateRenderedTexture();
  }

  void CreateRenderedTexture()
  {
    Debug.Log("CreateRenderedTexture");
    renderCamera.targetTexture = (RenderTexture)rawImage.texture;
    //renderCamera.targetTexture = (RenderTexture)material.GetTexture("RenderCamera");
  }
}
