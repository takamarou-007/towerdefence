using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //敵モブの生成のための経験値
    private int exPointToGenerate = 15;
    //自分が守っているタワーを認識
    private GameObject tower1;
    private GameObject tower2;
    private GameObject tower3;
    private GameObject tower4;
    //画面遷移用
    private float time = 0;

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
        //タワーの取得
        tower1 = GameObject.Find("Tower-1");
        tower2 = GameObject.Find("Tower-2");
        tower3 = GameObject.Find("Tower-3");
        tower4 = GameObject.Find("Tower-4");
    }

    private void Update()
    {
        if (alertColor.a == 1)
        {
            alertColor.a -= fadeoutSpeed;
            alert.GetComponent<Text>().color = alertColor;
        }
        //時間で経験値が入るように
        currentTime += Time.deltaTime;
        if (currentTime > span)
        {
            exPoint += 10;
            currentTime = 0f;
        }

        if (this.gameObject.tag == "Player1")
        {
            if(tower1 == null)
            {
                GameoverSceneManegement();
            }
        }
        if (this.gameObject.tag == "Player2")
        {
            if (tower2 == null)
            {
                GameoverSceneManegement();
            }
        }
        if (this.gameObject.tag == "Player3")
        {
            if (tower3 == null)
            {
                GameoverSceneManegement();
            }
        }
        if (this.gameObject.tag == "Player4")
        {
            if (tower4 == null)
            {
                GameoverSceneManegement();
            }
        }
    }
    void GameoverSceneManegement()
    {
        time += Time.deltaTime;
        if(time > 2.0f)
        {
            SceneManager.LoadScene("GameOverScene");
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

    //アタック強化の処理
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

    //スピード強化をの処理
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
        if(exPoint > exPointToGenerate)
        {
            randomSelectSpawnerScript.SelectSpawner1();
            exPoint -= exPointToGenerate;
        }
        else
        {
            alertColor.a = 1;
            Invoke("FadeOutText", 2);
            Debug.Log("経験値が足りないよ");
            return;
        }
    }
    public void ClickToGenerateEnemyMobPlayer2()
    {
        if (exPoint > exPointToGenerate)
        {
            randomSelectSpawnerScript.SelectSpawner2();
            exPoint -= exPointToGenerate;
        }
        else
        {
            alertColor.a = 1;
            Invoke("FadeOutText", 2);
            Debug.Log("経験値が足りないよ");
            return;
        }
    }
    public void ClickToGenerateEnemyMobPlayer3()
    {
        if (exPoint > exPointToGenerate)
        {
            randomSelectSpawnerScript.SelectSpawner3();
            exPoint -= exPointToGenerate;
        }
        else
        {
            alertColor.a = 1;
            Invoke("FadeOutText", 2);
            Debug.Log("経験値が足りないよ");
            return;
        }
    }
    public void ClickToGenerateEnemyMobPlayer4()
    {
        if (exPoint > exPointToGenerate)
        {
            randomSelectSpawnerScript.SelectSpawner4();
            exPoint -= exPointToGenerate;
        }
        else
        {
            alertColor.a = 1;
            Invoke("FadeOutText", 2);
            Debug.Log("経験値が足りないよ");
            return;
        }
    }
    
    //"経験値が足りないよ”を出すときに使っている
    void FadeOutText()
    {
        alertColor.a = 0;
        alert.GetComponent<Text>().color = alertColor;
    }
}
