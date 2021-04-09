using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamerasManager : MonoBehaviour
{
    public static CamerasManager instance;

    public RenderTextureToAssing[] assignableRenderTextures;
    public RawImage[] cameras;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AssignCameras();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AssignCameras();
        }
    }

    public void AssignCameras()
    {
        for (int i = 0; i < assignableRenderTextures.Length; i++)
        {
            assignableRenderTextures[i].isAssigned = false;
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            RenderTexture textureToAssign = getRightRenderTexture();

            if (textureToAssign != null)
            {
                cameras[i].texture = textureToAssign;
            }
        }
    }

    private RenderTexture getRightRenderTexture()
    {
        RenderTexture result = null;

        int randomNumber;

        do
        {
            randomNumber = Random.Range(0, assignableRenderTextures.Length);
        } while (assignableRenderTextures[randomNumber].isAssigned);

        result = assignableRenderTextures[randomNumber].renderTexture;
        assignableRenderTextures[randomNumber].isAssigned = true;

        return result;
    }

    [System.Serializable]
    public class RenderTextureToAssing
    {
        public RenderTexture renderTexture;
        [HideInInspector]
        public bool isAssigned;
    }
}
