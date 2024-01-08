using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPPV : MonoBehaviour
{
    private PostProcessVolume postPV;
    public PostProcessProfile globalCamera;
    public PostProcessProfile uiCamera;

    private void Start()
    {
        postPV = GetComponent<PostProcessVolume>();
        SwitchProfile(globalCamera);
    }

    public void SwitchToCamera()
    {
        SwitchProfile(uiCamera);
    }

    public void SwitchToGlobal()
    {
        SwitchProfile(globalCamera);
    }

    private void SwitchProfile(PostProcessProfile newProfile)
    {
        postPV.profile = newProfile;
    }
}