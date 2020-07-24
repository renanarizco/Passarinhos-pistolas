using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _CloudParticlePrefab;
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
        
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_CloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    }
}
