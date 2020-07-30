using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zoom : MonoBehaviour
{
    KeysControls _keysControls;

    //Habilita O Dont Destroy do Zoom e dá função a tecla de zoom.
    private void Awake()
    {
        _keysControls = new KeysControls();
        DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(GetComponent<Zoom>());
        _keysControls.Camera.Zoom.performed += _ => ZoomIn();
        _keysControls.Camera.Zoom.canceled += _ => ZoomOut();
    }

    //Se a cena atual não for o menu, faz a tecla de zoom poder ser apertada.
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == ("Menu"))
        {
            _keysControls.Disable();
        }
        else
        {
            _keysControls.Enable();
        }
    }


    //Faz a camera virtual seguir todos os personagens, fazendo o zoom diminuir.
    private void ZoomIn()
    {   
        Debug.Log("Zoom!");
        GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("ZoomGroup").transform;  
    }

    //Faz a camera virtual seguir só o pássaro, dando zoom nele.
    private void ZoomOut()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("TargetGroup").transform;
    }
}

