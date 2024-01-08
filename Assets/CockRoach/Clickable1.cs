using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clickable : MonoBehaviour
{
  void Start()
  {
    //PlayerPrefs.DeleteAll();
    PlayerPrefs.SetInt("rat1", 0);
    PlayerPrefs.SetInt("rat2", 0);
    

    if (PlayerPrefs.GetInt(gameObject.name) == 1)
    {
      gameObject.SetActive(false);
    }
  }
  public void OnMouseDown()
    {
      PlayerPrefs.SetInt(gameObject.name, 1);
      SceneManager.LoadScene("CockRoach");
    }

}
