using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetsRats : MonoBehaviour
{
    public void reset()
    {
        PlayerPrefs.SetInt("rat1", 0);
        PlayerPrefs.SetInt("rat2", 0);
    }
}
