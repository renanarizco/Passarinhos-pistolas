using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*      VARIÁVEIS       */
    //Variável privada _CloudParticlePrefab que guarda a nuvem que aparece quando um monstro é derrotado.
    [SerializeField] private GameObject _CloudParticlePrefab; 

    //Variável que controla o nome da explosão.
    private string _randomExplosion;


    /*      CONSTRUTORES        */
    private Enemy(GameObject cloudParticlePrefab)
    {
        _CloudParticlePrefab = cloudParticlePrefab;
    }


    /*      MÉTODOS     */
    //Roda quando o monstro morre.
    private void MonsterDied()
    {
        Instantiate(_CloudParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

        //Faz a explosão ser aleatória.
        _randomExplosion = "Explosion" + Random.Range(1, 4);

        //Toca o som de explosão.
        GameObject.Find(_randomExplosion).GetComponent<AudioSource>().Play();

        Debug.Log("Morreu um monstro");
    }

    //Método que calcula quando o pássaro ou a caixa entra em contato com o monstro, fazendo ele sumir com uma nuvem.
    //Agora ele detecta colisão com o chão também.
    private void OnCollisionEnter2D(Collision2D collision) {
        Bird bird = collision.collider.GetComponent<Bird>();
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        Ground ground = collision.collider.GetComponent<Ground>();

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
        
        if (ground != null)
        {
            MonsterDied();
            return;
        }
        
        //Se a caixa cair em cima da cabeça dele (y < -0.5), mata o monstro.
        if (collision.GetContact(0).normal.y < -0.5)
        {
            MonsterDied();
        } 
    }
}
