using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//機能していない
public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    //時間間隔最小値
    public float minTime = 2f;
    //時間間隔最大値
    public float maxTime = 5f;
    //出現位置ランダム化
    public float xminPosition = -10f;
    public float xmaxPosition = 10f;
    public float yminPosition = 1f;
    public float ymaxPosition = 3f;
    public float zminPosition = -10f;
    public float zmaxPosition = 10f;

    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;

    private void Start()
    {
        interval = GetRandomTime();
    }
    private void Update()
    {
        //時間計測
        time += Time.deltaTime;
        //経過時間が生成時間になったとき
        if(time > interval)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            //生成した敵の座標を決定する
            enemy.transform.position = GetRandomPosition();
            //経過時間を初期化
            time = 0f;
            //次に発生する時間間隔を決定
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
