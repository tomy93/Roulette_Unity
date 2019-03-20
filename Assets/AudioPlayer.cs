using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip roulette;
    [SerializeField] private AudioClip check;
    [SerializeField] private AudioClip uncheck;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip lose;
    [SerializeField] private AudioClip inactive;
    private AudioSource aS;

    public static AudioPlayer instance;

    private void Awake()
    {
        instance = this;
        aS = GetComponent<AudioSource>();
    }

    public void PlayRouletteClip()
    {
        aS.PlayOneShot(roulette);
    }
    public void PlayGoodAnswer()
    {
        aS.PlayOneShot(check);
    }
    public void PlayBadAnswer()
    {
        aS.PlayOneShot(uncheck);
    }
    public void PlayWin()
    {
        aS.PlayOneShot(win);
    }
    public void PlayLose()
    {
        aS.PlayOneShot(lose);
    }
    public void PlayInactive()
    {
        aS.PlayOneShot(inactive);
    }
}
