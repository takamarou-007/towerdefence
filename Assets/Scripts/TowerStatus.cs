using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerStatus : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private float time;

    private void Start()
    {
        time = 0f;
    }

    private void Update()
    {
        if (tower)
        {
            return;
        }
        else
        {
            time += Time.deltaTime;
            if (time > 3.0f)
            {
                SceneManager.LoadScene("GameOverScene");
            }
          
        }
    }
}
