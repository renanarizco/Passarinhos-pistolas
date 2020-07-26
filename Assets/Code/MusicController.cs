using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //Procura o objeto com a tag musica e toca.
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusic>().PlayMusic();
    }
}
