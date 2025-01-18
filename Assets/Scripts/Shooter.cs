using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int projectileSpeed = 10;
    [SerializeField] float projectileLifetime = 4.5f;
    [SerializeField] float baseFiringSpeed = 2f;

    [Header("AI")]
    [SerializeField] float firingSpeedVariance = 1.5f;
    [SerializeField] float fastestFiringRate = 0.5f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

   
    void Update()
    {        
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null) 
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            audioPlayer.PlayShootingClip();
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(GetRandomFiringSpeed());
        }
        
    }

    float GetRandomFiringSpeed()
    {
        float newFiringSpeed = Random.Range(baseFiringSpeed - firingSpeedVariance, baseFiringSpeed + firingSpeedVariance);
        return Mathf.Clamp(newFiringSpeed, fastestFiringRate, float.MaxValue);
    }

}
