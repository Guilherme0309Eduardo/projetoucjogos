using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameController : MonoBehaviour
{
    public static GameController gc;
    public Text CoinsText;
    public int Coins;
    public Text timeText;
    public float timeCount;
    public bool timeOver = false;

    void Awake()
    {
        if (gc == null)  // Corrigido o erro de comparação
        {
            gc = this;
        }
        else if (gc != this)
        {
            Destroy(gameObject);
        }
    }

    public void RefreshScreen()
    {
        CoinsText.text = Coins.ToString();
        timeText.text = timeCount.ToString("F0");
    }

    private void Update()
    {
        TimeCount();
    }

    void TimeCount()
    {
        if (!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            RefreshScreen();

            if (timeCount <= 0)
            {
                timeCount = 0;
                timeOver = true;
            }
        }
    }
}

