using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

    public GameObject canvas;

    private void Start()
    {
        subCamera.enabled = false;
    }

    private void Update()
    {
        
    }

    //ボタンを押したときの処理
    public void PushButton()
    {
        //もしカメラがオフだったら
        if (!subCamera.enabled)
        {
            //サブカメラをオンにして、メインカメラをオフにする
            subCamera.enabled = true;
            mainCamera.enabled = false;
            canvas.GetComponent<Canvas>().worldCamera = subCamera;
        }
        //もしサブカメラがオンだったら
        else
        {
            //メインカメラをオンにして、サブカメラをオフにする
            subCamera.enabled = false;
            mainCamera.enabled = true;
            canvas.GetComponent<Canvas>().worldCamera = mainCamera;
        }
    }
}
