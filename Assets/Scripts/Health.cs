using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyShake;
    ShakeCamera shakeCamera;
    [SerializeField] bool playDmgClip;
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreForKill = 50;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        shakeCamera = Camera.main.GetComponent<ShakeCamera>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null )
        {
            if (playDmgClip)
            {
                audioPlayer.PlayDamageRecieveClip();
            }
            TakeDamage(damageDealer.GetDamage());
            PlayShake();
            PlayHitEffect();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
         
        health -= damage;
        if (health <= 0)
        {
            if (!isPlayer)
            {
                scoreKeeper.AddScore(scoreForKill);
            }
            Destroy(gameObject);
            if (isPlayer)
            {
                levelManager.LoadGameOver();
            }
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void PlayShake()
    {
        if (shakeCamera != null && applyShake)
        {
            shakeCamera.PlayShake();
        }
    }

    public int GetHealth()
    {  return health; }

}
