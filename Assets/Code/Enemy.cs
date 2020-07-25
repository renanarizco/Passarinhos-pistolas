using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*      VARIÁVEIS    */
    //Variável privada _CloudParticlePrefab que guarda a nuvem que aparece quando um monstro é derrotado.
    [SerializeField] private GameObject _CloudParticlePrefab;



    /*      MÉTODOS    */
    //Método que calcula quando o pássaro ou a caixa entra em contato com o monstro, fazendo ele sumir com uma nuvem.
    private void OnCollisionEnter2D(Collision2D collision) {
        Bird bird = collision.collider.GetComponent<Bird>();
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (bird != null)
        {
            Instantiate(_CloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        if (enemy != null)
        {
            return;
        }
        
        //Se a caixa cair em cima da cabeça dele (y < -0.5), mata o monstro.
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_CloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    }
}
