using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    //Serve para que a musica de fundo não suma quando a fase troca.
     private AudioSource _audioSource;
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         DontDestroyOnLoad(_audioSource = GetComponent<AudioSource>());
     }
 
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }

     
 }
