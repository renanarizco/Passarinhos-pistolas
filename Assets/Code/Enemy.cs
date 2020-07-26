using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*      VARIÁVEIS    */
    //Variável privada _CloudParticlePrefab que guarda a nuvem que aparece quando um monstro é derrotado.
    [SerializeField] private GameObject _CloudParticlePrefab;



    /*      MÉTODOS    */
    //Roda quando o monstro morre.
    private void MonsterDied()
    {
        GameObject.FindGameObjectWithTag("EnemyDying").GetComponent<AudioSource>().Play();
        Instantiate(_CloudParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("Morreu um monstro");
    }

    //Método que calcula quando o pássaro ou a caixa entra em contato com o monstro, fazendo ele sumir com uma nuvem.
    private void OnCollisionEnter2D(Collision2D collision) {
        Bird bird = collision.collider.GetComponent<Bird>();
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (bird != null)
        {
            MonsterDied();
            return;
        }

        if (enemy != null)
        {
            MonsterDied();
            return;
        }
        
        //Se a caixa cair em cima da cabeça dele (y < -0.5), mata o monstro.
        if (collision.contacts[0].normal.y < -0.5)
        {
            MonsterDied();
        } 
    }
}
