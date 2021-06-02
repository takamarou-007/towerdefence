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

    //�{�^�����������Ƃ��̏���
    public void PushButton()
    {
        //�����J�������I�t��������
        if (!subCamera.enabled)
        {
            //�T�u�J�������I���ɂ��āA���C���J�������I�t�ɂ���
            subCamera.enabled = true;
            mainCamera.enabled = false;
            canvas.GetComponent<Canvas>().worldCamera = subCamera;
        }
        //�����T�u�J�������I����������
        else
        {
            //���C���J�������I���ɂ��āA�T�u�J�������I�t�ɂ���
            subCamera.enabled = false;
            mainCamera.enabled = true;
            canvas.GetComponent<Canvas>().worldCamera = mainCamera;
        }
    }
}
