using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.FPS.Gameplay;
using Unity.FPS.Game;

public class Timermurase: MonoBehaviour
{
    public Health health;

    private void Start()
    {
        if(health == null)
        {
            health=transform.GetComponent<Health>();
        }
    }
    //カウントダウン
    public float countdown = 5.0f;

    //時間を表示するText型の変数
    public TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1");

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "時間になりました！";
            health.Kill();
        }
    }
}
