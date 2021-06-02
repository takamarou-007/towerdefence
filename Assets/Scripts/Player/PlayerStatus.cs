using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MobStatus
{
    //基本的な要素
    [SerializeField] NewPlayerController playerScript;
    [SerializeField] MobAttack mobAttackScript;
    [SerializeField] TextManager textManager;
    public int attack;
    public float speed = 10;
    public float exPoint = 0;
    private float needExPoint;

    //次のステータスに行くために必要な経験値がリストになっている
    public int[] attackCounter;
    public int[] speedCounter;
    //今のステータスがどの段階にいるか
    public int attackLevel = 1;
    public int speedLevel = 1;
    //経験値が足りない時の警告文（経験値が足りないよ）表示
    public GameObject alertText;
    private Text alert;
    private Color alertColor;
    public float fadeoutSpeed = 0.05f;
    //警告文用
    public float span = 10f;
    private float currentTime = 0f;
    //敵Mob生成のためのもの
    [SerializeField] RandomSelectSpawnerToSendEnemyToOthers randomSelectSpawnerScript;
    public GameObject canvasToMob;
    public GameObject buttonEnemyToPlayer1;
    public GameObject buttonEnemyToPlayer2;
    public GameObject buttonEnemyToPlayer3;
    public GameObject buttonEnemyToPlayer4;

    protected override void Start()
    {
        base.Start();
        playerScript = GetComponent<NewPlayerController>();
        mobAttackScript = GetComponent<MobAttack>();
        textManager = GetComponent<TextManager>();
        //警告文用
        alert = alertText.GetComponent<Text>();
        alertColor = alert.GetComponent<Text>().color;
        alertColor.a = 0;
        alert.GetComponent<Text>().color = alertColor;
    }

    private void Update()
    {
        if (alertColor.a == 1)
        {
            alertColor.a -= fadeoutSpeed;
            alert.GetComponent<Text>().color = alertColor;
        }

        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            exPoint += 10;
            currentTime = 0f;
        }
    }

    //ボタンを押すことで、Speedを強化する
    public void ClickToReinforcementSpeed()
    {
        SpeedLevelCounter(speedLevel);
        DoReinforcementSpeed();
    }

    //ボタンを押すことで、Attackを強化する
    public void ClickToReinforcementAttack()
    {
        AttackLevelCounter(attackLevel);
        DoReinforcementAttack();
    }

    public void DoReinforcementAttack()
    {
        if (exPoint >= needExPoint)
        {
            attack += 1;
            exPoint -= needExPoint;
            attackLevel += 1;
        }
        else
        {
            alertColor.a = 1;
            Invoke("FadeOutText", 2);
            Debug.Log("経験値が足りないよ");
            return;
        }
    }

    public void DoReinforcementSpeed()
    {
        if (exPoint >= needExPoint)
        {
            speed += 1;
            exPoint -= needExPoint;
            speedLevel += 1;
        }
        else
        {
            alertColor.a = 1;
            Invoke("FadeOutText", 2);
            Debug.Log("経験値が足りないよ");
            return;
        }
    }

    //ClickToReinfocementAttackのところでif文で各レベルについて書いてもよかったが、チャレンジしてみた
    public void AttackLevelCounter(int levelcounter)
    {

        if (attackLevel == levelcounter)
        {
            needExPoint = attackCounter[levelcounter - 1];

            if (attackLevel == 10)
            {
                Debug.Log("限界値");
                return;
            }
        }
        else
        {
            Debug.Log("は？");
            return;
        }

    }

    //上記と一緒
    public void SpeedLevelCounter(int levelcounter)
    {
        if (speedLevel == levelcounter)
        {
            needExPoint = speedCounter[levelcounter - 1];

            if (speedLevel == 10)
            {
                Debug.Log("限界値");
                return;
            }
        }
        else
        {
            Debug.Log("は？");
            return;
        }

    }

    //敵Mobを敵フィールドに送るための実装
    //ボタンの表示
    public void ClickToSetCanvasToSend()
    {
        canvasToMob.SetActive(true);

        if (this.gameObject.tag == "Player1")
        {
            buttonEnemyToPlayer1.SetActive(false);
            buttonEnemyToPlayer2.SetActive(true);
            buttonEnemyToPlayer3.SetActive(true);
            buttonEnemyToPlayer4.SetActive(true);
        }
        if (this.gameObject.tag == "Player2")
        {
            buttonEnemyToPlayer1.SetActive(true);
            buttonEnemyToPlayer2.SetActive(false);
            buttonEnemyToPlayer3.SetActive(true);
            buttonEnemyToPlayer4.SetActive(true);
        }
        if (this.gameObject.tag == "Player3")
        {
            buttonEnemyToPlayer1.SetActive(true);
            buttonEnemyToPlayer2.SetActive(true);
            buttonEnemyToPlayer3.SetActive(false);
            buttonEnemyToPlayer4.SetActive(true);
        }
        if (this.gameObject.tag == "Player4")
        {
            buttonEnemyToPlayer1.SetActive(true);
            buttonEnemyToPlayer2.SetActive(true);
            buttonEnemyToPlayer3.SetActive(true);
            buttonEnemyToPlayer4.SetActive(false);
        }
    }

    //敵フィールドへの敵Mobの送還
    public void ClickToCenerateEnemyMobPlayer1()
    {
        randomSelectSpawnerScript.SelectSpawner1();
    }
    public void ClickToGenerateEnemyMobPlayer2()
    {
        randomSelectSpawnerScript.SelectSpawner2();
    }
    public void ClickToGenerateEnemyMobPlayer3()
    {
        randomSelectSpawnerScript.SelectSpawner3();
    }
    public void ClickToGenerateEnemyMobPlayer4()
    {
        randomSelectSpawnerScript.SelectSpawner4();
    }
    
    //”経験値が足りないよ”を出すときに使っている
    void FadeOutText()
    {
        alertColor.a = 0;
        alert.GetComponent<Text>().color = alertColor;
    }
}
