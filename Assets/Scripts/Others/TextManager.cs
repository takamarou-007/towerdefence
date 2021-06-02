using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject speedText;
    public GameObject attackText;  
    public GameObject player;
    private float speedStatus;
    private int attackStatus;
    public GameObject exPointText;
    private float exPoint;


    public GameObject timeText;
    private int minute;
    private float seconds;
    private float oldSeconds;

    private void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;

        
    }

    
    private void Update()
    {
        speedStatus = player.GetComponent<PlayerStatus>().speed;
        attackStatus = player.GetComponent<PlayerStatus>().attack;
        exPoint = player.GetComponent<PlayerStatus>().exPoint;
        Text speed = speedText.GetComponent<Text>();
        Text attack = attackText.GetComponent<Text>();
        Text point = exPointText.GetComponent<Text>();
        speed.text = "ë¨ìx : " + speedStatus;
        attack.text = "çUåÇóÕ :" + attackStatus;
        point.text = "åoå±íl : " + exPoint;
        

        Text time = timeText.GetComponent<Text>();
        seconds += Time.deltaTime;
        if (seconds >=  60f)
        {
            minute++;
            seconds = seconds - 60f;
        }
        if ((int)seconds != (int)oldSeconds)
        {
            time.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            oldSeconds = seconds;
        }
        
    }

    
    
}
