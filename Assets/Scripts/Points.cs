using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static Points instance;

    public Text ScoreText;

    int score = 0;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ScoreText.text = score.ToString() + "Points";
    }

    public void AddPoint()
    {
        score += 1;
        ScoreText.text = score.ToString() + "Points";
    }
}
