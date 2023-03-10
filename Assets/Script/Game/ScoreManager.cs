using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static float score;
    public Player player;
    public SpriteRenderer plantRenderer;
    public List<Sprite> plantSprites;
    public float speedIncrease = 1 / 150;
    public float scoreThreshold = 200;
    public AudioSource musicSoft;
    public AudioSource musicHard;
    float backgroundVolume;

    private void Start()
    {
        if(musicSoft) {
            backgroundVolume = musicSoft.volume;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(player && player.hp > 0)
        {
            string textualScore = ((int)score - 6).ToString();
            score += 1 * Time.deltaTime;
            Time.timeScale = 1 + 1 * score * speedIncrease;
            scoreText.text = ((int)score).ToString();
            if (musicSoft)
            {
                musicSoft.volume = backgroundVolume * (1 - score / (plantSprites.Count * scoreThreshold));
            }
            if (musicHard)
            {
                musicHard.volume = backgroundVolume * (score / (plantSprites.Count * scoreThreshold));
            }
        } else {
            scoreText.text = "Score : " + ((int)score).ToString();
            int spriteIndex = (int) (score / scoreThreshold);
            if(plantRenderer) plantRenderer.sprite = plantSprites[spriteIndex > plantSprites.Count - 1 ? plantSprites.Count - 1 : spriteIndex];
        }
    }
}
