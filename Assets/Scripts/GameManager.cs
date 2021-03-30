using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GameManager : MonoBehaviour
{


    [SerializeField] private int pointsPerCoinCollected = 1;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Awake()
    {
        currentScore = 0;
        scoreText = FindObjectOfType<TextMeshProUGUI>();
    }
    private void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
        
    }
    public void AddToScore()
    {
        if (scoreText != null)
        {
            currentScore = currentScore + pointsPerCoinCollected;
            scoreText.text = currentScore.ToString();
            StartCoroutine(ScorePulse());
        }
        
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private IEnumerator ScorePulse()
    {
        if (scoreText != null)
        {
            for (float i = 1f; i <= 1.4f; i += 0.05f)
            {
                scoreText.rectTransform.localScale = new Vector3(i, i, i);
                yield return new WaitForEndOfFrame();
            }
            scoreText.rectTransform.localScale = new Vector3(1.4f, 1.4f, 1.4f);

            for (float i = 1.4f; i >= 1f; i -= 0.05f)
            {
                scoreText.rectTransform.localScale = new Vector3(i, i, i);
                yield return new WaitForEndOfFrame();
            }
            scoreText.rectTransform.localScale = new Vector3(1, 1, 1);

        }
       
    }

}