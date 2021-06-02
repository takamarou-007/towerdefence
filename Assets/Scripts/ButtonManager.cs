using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject canvas;

    public void TurnOffTheDisplay()
    {
        canvas.SetActive(false);
    }
}
