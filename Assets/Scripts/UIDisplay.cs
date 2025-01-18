using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health health;
    [SerializeField] Slider healthBar;
    [Header("Score")]
    ScoreKeeper scoreKeeper;    
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {   
        scoreKeeper = FindObjectOfType<ScoreKeeper>();        
    }
    void Start()
    {
        healthBar.maxValue = health.GetHealth();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
        healthBar.value = health.GetHealth();
    }

}
