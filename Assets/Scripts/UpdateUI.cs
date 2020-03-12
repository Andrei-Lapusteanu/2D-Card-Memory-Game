using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    static GameObject scoreUI, triesUI, successRateUI;
    static Text textScore, textTries, textSuccessRate;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GameObject.Find("Score");
        triesUI = GameObject.Find("Tries");
        successRateUI = GameObject.Find("Success");

        textScore = scoreUI.GetComponent<Text>();
        textTries = triesUI.GetComponent<Text>();
        textSuccessRate = successRateUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score: " + Stats.Score;
        textTries.text = "Tries: " + Stats.Tries;
        textSuccessRate.text = "Success: " + Stats.SuccessRate.ToString("0.00") + "%";
    }
}
