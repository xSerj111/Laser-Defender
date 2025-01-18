using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 0.4f;

    [Header("Damage Recieved")]
    [SerializeField] AudioClip damageRecieveClip;
    [SerializeField][Range(0f, 1f)] float dmgRecVolume = 1f;

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }
    public void PlayDamageRecieveClip()
    {
        PlayClip(damageRecieveClip, dmgRecVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
