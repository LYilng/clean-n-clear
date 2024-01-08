using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPPV : MonoBehaviour
{
    public static CameraPPV instance;

    private PostProcessVolume postPV;
    public PostProcessProfile globalCamera;
    public PostProcessProfile uiCamera;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        postPV = GetComponent<PostProcessVolume>();
        SwitchProfile(globalCamera);
    }

    public void SwitchToCamera() //Blur
    {
        SwitchProfile(uiCamera);
    }

    public void SwitchToGlobal() //Normal
    {
        SwitchProfile(globalCamera);
    }

    private void SwitchProfile(PostProcessProfile newProfile)
    {
        postPV.profile = newProfile;
    }
}