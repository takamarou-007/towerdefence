using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelectSpawnerToSendEnemyToOthers : MonoBehaviour
{
    [SerializeField] GameObject[] spawners1;
    [SerializeField] GameObject[] spawners2;
    [SerializeField] GameObject[] spawners3;
    [SerializeField] GameObject[] spawners4;

    
    
    public void SelectSpawner1()
    {
        var randomValue = Random.Range(0, spawners1.Length);
        spawners1[randomValue].SetActive(true);
    }
    public void SelectSpawner2()
    {
        var randomValue = Random.Range(0, spawners2.Length);
        spawners2[randomValue].SetActive(true);
    }
    public void SelectSpawner3()
    {
       int randomValue = Random.Range(0, spawners3.Length);
       spawners3[randomValue].SetActive(true);
    }
    
    public void SelectSpawner4()
    {
        int randomValue = Random.Range(0, spawners4.Length);
        spawners4[randomValue].SetActive(true);
    }
    

    
}
