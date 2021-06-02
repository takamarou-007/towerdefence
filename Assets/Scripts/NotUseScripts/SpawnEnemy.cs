using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float interval;
    //‚±‚ÌêŠ‚©‚çoŒ»‚·‚é“G‚Ì”
    [SerializeField] int maxEnemy;
    //“G‚ðoŒ»‚³‚¹‚½‘”
    private int countOfEnemy;
    //‘Ò‚¿ŽžŠÔŒv‘ª
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
