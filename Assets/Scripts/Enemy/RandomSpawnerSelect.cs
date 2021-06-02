using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerSelect : MonoBehaviour
{
    //�����_���ɓG�𐶐�����X�|�i�[��I������X�N���v�g

    [SerializeField] GameObject[] spawners;
    [SerializeField] float nextTime;
    [SerializeField] float waitedTime;


    private void Start()
    {
        waitedTime = 0f;
    }

    private void Update()
    {
        waitedTime += Time.deltaTime;

        if (waitedTime > nextTime)
        {
            waitedTime = 0f;

            SelectSpawner();
        }


    }

    void SelectSpawner()
    {
        var randomValue = Random.Range(0, spawners.Length);
        spawners[randomValue].SetActive(true);

    }
}
