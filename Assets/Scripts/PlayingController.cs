using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingController : MonoBehaviour
{
    private KeysControls keyscontrols;

    private void Awake() 
    {
        keyscontrols = new KeysControls();   
    }

    private void OnEnable() 
    {
        keyscontrols.Enable();
    }

    private void OnDisable() 
    {
        keyscontrols.Disable();
    }

    void Start()
    {
        keyscontrols.Fase.Exit.performed += _ => Quit();
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
