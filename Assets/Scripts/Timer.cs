using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI namespace
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float _timer = 10f;
    public bool timerOn = false;

    public TMP_Text timerTxt;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if(_timer >= 0f)
            {
                _timer -= Time.deltaTime;
                UpdateTimer(_timer);
            }
            else
            {
                Debug.Log("Time is UP!");
                _timer = 0;
                timerOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    { currentTime += 1;

        currentTime = Mathf.Max(0, currentTime);
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
