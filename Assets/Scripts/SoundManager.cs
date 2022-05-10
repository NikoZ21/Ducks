using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Stop Sound")]
    [SerializeField] AudioClip stopSFX;
    [SerializeField] [Range(0, 1f)] float stopSFXVolume = 0.5f;

    [Header("Correct Sound")]
    [SerializeField] AudioClip correctSFX;
    [SerializeField] [Range(0, 1f)] float correctSFXVolume = 0.5f;

    [Header("Wrong Sound")]
    [SerializeField] AudioClip wrongSFX;
    [SerializeField] [Range(0, 1f)] float wrongSFXVolume = 0.5f;

    [Header("Pop Sound")]
    [SerializeField] AudioClip popSFX;
    [SerializeField] [Range(0, 1f)] float popSFXVolume = 0.5f;

    private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PopSound(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(popSFX, position, popSFXVolume);
    }

    public void CorrectSound()
    {
        _audioSource.clip = correctSFX;
        _audioSource.volume = correctSFXVolume;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    public void DuckStoppingSound(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(stopSFX, position, stopSFXVolume);
    }

    public void WrongSound(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(wrongSFX, position, wrongSFXVolume);
    }
}
