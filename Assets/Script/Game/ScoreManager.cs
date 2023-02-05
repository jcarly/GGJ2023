using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static float score = 0;
    public static float offsetedScore = score - 6;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            string textualScore = ((int)score - 6).ToString();
            offsetedScore = score - 6;
            score += 1 * Time.deltaTime;

            Time.timeScale = offsetedScore < 0f ? 2 : 1 + 1 * (score / 150);
            scoreText.text = offsetedScore < 0f ? "0" : textualScore;
            
        } else {
            scoreText.text = "Score : " + ((int)score).ToString();
        }
    }
}
