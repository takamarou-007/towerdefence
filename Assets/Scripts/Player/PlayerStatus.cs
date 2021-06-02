using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MobStatus
{
    //��{�I�ȗv�f
    [SerializeField] NewPlayerController playerScript;
    [SerializeField] MobAttack mobAttackScript;
    [SerializeField] TextManager textManager;
    public int attack;
    public float speed = 10;
    public float exPoint = 0;
    private float needExPoint;
    //���̃X�e�[�^�X�ɍs�����߂ɕK�v�Ȍo���l�����X�g�ɂȂ��Ă���
    public int[] attackCounter;
    public int[] speedCounter;
    //���̃X�e�[�^�X���ǂ̒i�K�ɂ��邩
    public int attackLevel = 1;
    public int speedLevel = 1;
    //�o���l������Ȃ����̌x�����i�o���l������Ȃ���j�\��
    public GameObject alertText;
    private Text alert;
    private Color alertColor;
    public float fadeoutSpeed = 0.05f;
    //�x�����p
    public float span = 10f;
    private float currentTime = 0f;
    //�GMob�����̂��߂̂���
    [SerializeField] RandomSelectSpawnerToSendEnemyToOthers randomSelectSpawnerScript;
    public GameObject canvasToMob;
    public GameObject buttonEnemyToPlayer1;
    public GameObject buttonEnemyToPlayer2;
    public GameObject buttonEnemyToPlayer3;
    public GameObject buttonEnemyToPlayer4;
    //�G���u�̐����̂��߂̌o���l
    private int exPointToGenerate = 15;
    //����������Ă���^���[��F��
    private GameObject tower1;
    private GameObject tower2;
    private GameObject tower3;
    private GameObject tower4;
    //��ʑJ�ڗp
    private float time = 0;

    protected override void Start()
    {
        base.Start();
        playerScript = GetComponent<NewPlayerController>();
        mobAttackScript = GetComponent<MobAttack>();
        textManager = GetComponent<TextManager>();
        //�x�����p
        alert = alertText.GetComponent<Text>();
        alertColor = alert.GetComponent<Text>().color;
        alertColor.a = 0;
        alert.GetComponent<Text>().color = alertColor;
        //�^���[�̎擾
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
        //���ԂŌo���l������悤��
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

    //�{�^�����������ƂŁASpeed����������
    public void ClickToReinforcementSpeed()
    {
        SpeedLevelCounter(speedLevel);
        DoReinforcementSpeed();
    }

    //�{�^�����������ƂŁAAttack����������
    public void ClickToReinforcementAttack()
    {
        AttackLevelCounter(attackLevel);
        DoReinforcementAttack();
    }

    //�A�^�b�N�����̏���
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
            Debug.Log("�o���l������Ȃ���");
            return;
        }
    }

    //�X�s�[�h�������̏���
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
            Debug.Log("�o���l������Ȃ���");
            return;
        }
    }

    //ClickToReinfocementAttack�̂Ƃ����if���Ŋe���x���ɂ��ď����Ă��悩�������A�`�������W���Ă݂�
    public void AttackLevelCounter(int levelcounter)
    {

        if (attackLevel == levelcounter)
        {
            needExPoint = attackCounter[levelcounter - 1];

            if (attackLevel == 10)
            {
                Debug.Log("���E�l");
                return;
            }
        }
        else
        {
            Debug.Log("�́H");
            return;
        }

    }

    //��L�ƈꏏ
    public void SpeedLevelCounter(int levelcounter)
    {
        if (speedLevel == levelcounter)
        {
            needExPoint = speedCounter[levelcounter - 1];

            if (speedLevel == 10)
            {
                Debug.Log("���E�l");
                return;
            }
        }
        else
        {
            Debug.Log("�́H");
            return;
        }

    }

    //�GMob��G�t�B�[���h�ɑ��邽�߂̎���
    //�{�^���̕\��
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

    //�G�t�B�[���h�ւ̓GMob�̑���
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
            Debug.Log("�o���l������Ȃ���");
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
            Debug.Log("�o���l������Ȃ���");
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
            Debug.Log("�o���l������Ȃ���");
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
            Debug.Log("�o���l������Ȃ���");
            return;
        }
    }
    
    //"�o���l������Ȃ���h���o���Ƃ��Ɏg���Ă���
    void FadeOutText()
    {
        alertColor.a = 0;
        alert.GetComponent<Text>().color = alertColor;
    }
}
