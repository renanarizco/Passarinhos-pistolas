using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MenuOpções : MonoBehaviour
{
    public AudioMixer audioMixer;

    //Função pra trocar o volume nas opções
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
