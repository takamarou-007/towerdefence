using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public void BackToHomeButton()
    {
        SceneManager.LoadScene("Home");
    }

    public void ToPlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
