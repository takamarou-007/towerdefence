using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    private void OnEnable()
    {
        float randomRotaition = Random.value * 360f;
        GameObject.Instantiate(enemy, transform.position, Quaternion.Euler(0f, randomRotaition, 0f));

        this.gameObject.SetActive(false);
    }
}
