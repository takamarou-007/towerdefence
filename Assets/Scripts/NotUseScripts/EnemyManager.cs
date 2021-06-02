using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�@�\���Ă��Ȃ�
public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    //���ԊԊu�ŏ��l
    public float minTime = 2f;
    //���ԊԊu�ő�l
    public float maxTime = 5f;
    //�o���ʒu�����_����
    public float xminPosition = -10f;
    public float xmaxPosition = 10f;
    public float yminPosition = 1f;
    public float ymaxPosition = 3f;
    public float zminPosition = -10f;
    public float zmaxPosition = 10f;

    //�G�������ԊԊu
    private float interval;
    //�o�ߎ���
    private float time = 0f;

    private void Start()
    {
        interval = GetRandomTime();
    }
    private void Update()
    {
        //���Ԍv��
        time += Time.deltaTime;
        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�
        if(time > interval)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            //���������G�̍��W�����肷��
            enemy.transform.position = GetRandomPosition();
            //�o�ߎ��Ԃ�������
            time = 0f;
            //���ɔ������鎞�ԊԊu������
            interval = GetRandomTime();
        }
    }

    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(xminPosition, xmaxPosition);
        float y = Random.Range(xminPosition, xmaxPosition);
        float z = Random.Range(zminPosition, zmaxPosition);

        return new Vector3(x, y, z);
    }
}
