using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static float score;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        if(player && player.hp > 0)
        {
            score += 1 * Time.deltaTime;
            Time.timeScale = 1 + 1 * (score / 150);
            scoreText.text = ((int)score).ToString();
            
        } else {
            scoreText.text = "Score : " + ((int)score).ToString();
        }
    }
}
