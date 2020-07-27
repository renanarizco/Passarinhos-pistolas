using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{

    /*      VARIÁVEIS    */
    //Variável _initialPosition que guarda a informação da posição inicial definida no editor de level do Unity.
    private Vector3 _initialPosition;

    //Variável _birdWasLaunched que vira true quando o pássaro é lançado.
    private bool _birdWasLaunched;

    //Variável _timeSittingAround que faz com que quando o pássaro fique parado aumente.
    private float _timeSittingAround;

    //Variável _launchPower que faz com que a potência do vôo do pássaro aumente.
    private float _launchPower = 350;

    //Variável responsável pelo texto do tutorial.
    private GameObject texttutorial;



    /*      MÉTODOS    */
    //Faz com que ao iniciar o jogo a variável _initialPosition receba a posição definida pelo editor de level do unity.
    private void Awake()
    {
        texttutorial = new GameObject();
        _initialPosition = transform.position;
    }

    //Se o pássaro foi lançado e a velocidade dele for menor que 0.1, faz com que a variável _timeSittingAround aumente.
    //Se o Update detectar que o pássaro saiu dos limites do mapa ou o tempo parado foi maior que o tanto definido ali, a cena reseta.
    //Ao lançar o pássaro, o texto de tutorial é excluido.
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.5)
        {
            _timeSittingAround = _timeSittingAround + Time.deltaTime;
        }

        if (_birdWasLaunched)
        {
            texttutorial = GameObject.FindGameObjectWithTag("TextTutorial");
            Destroy(texttutorial);
        }

        if (
            transform.position.y > 20 || transform.position.y < -15 ||
            transform.position.x > 30 || transform.position.x < -30 ||
            _timeSittingAround > 3
            )
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
    }

    //Ao apertar o mouse  no pássaro, ele fica com a cor vermelha e aparece setas mostrando a direção que ele irá ser lançado.
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
        
    }
    
    //Ao soltar o mouse faz com que o pássaro volte a ser branco, depois a variável directionToInitialPosition recebe a posição inicial do pássaro - a posição nova.
    //Depois, o .AddForce do RigidBody recebe a direção que o pássaro vai voar * o poder de lançamento definido anteriormente.
    //A variável _birdWasLaunched ativa dizendo que o pássaro foi lançado com sucesso e as setas são desativadas.
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    //Ao segurar o mouse faz com que o pássaro siga o cursor, transformando seu x e y no do cursor.
    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
