using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float interval;
    //この場所から出現する敵の数
    [SerializeField] int maxEnemy;
    //敵を出現させた総数
    private int countOfEnemy;
    //待ち時間計測
    private float elapsedTime;

    private void Start()
    {
        countOfEnemy = 0;
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (countOfEnemy >= maxEnemy)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime > interval)
        {
            elapsedTime = 0f;
            ApperEnemy();
        }
    }

    void ApperEnemy()
    {
        float randomRotation = Random.value * 360f;
        GameObject.Instantiate(enemy, transform.position, Quaternion.Euler(0f, randomRotation, 0f));

        countOfEnemy++;
        elapsedTime = 0f;
    }


}
