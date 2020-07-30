using System.Collections;
using UnityEngine;

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
    private float _launchPower = 360;

    //Variável responsável pelo texto do tutorial.
    private GameObject _textTutorial;

    //Variáveis que controlam a posição dos limites do cenário
    private int _mapPositiveX = 30, _mapNegativeX = -30, _mapPositiveY = 20, _mapNegativeY = -15;

    //Variável que controla o nome do sprite de colisão do pássaro.
    public Sprite BirdHit;

    //Variável que controla o tempo necessário pro sprite do pássaro trocar ao parar de colidir.
    private float _timeToSpriteChange = 1.6f;

    //Distância máxima de drag
    private float _maxDragDistance = 3f;
    
    //Objeto usado como referência pra calculo de física, basicamente é onde o pássaro nasce.
    public Rigidbody2D Hook;


    /*      MÉTODOS    */
    //Faz com que ao iniciar o jogo a variável _initialPosition receba a posição definida pelo editor de level do unity.
    private void Awake()
    {
        _textTutorial = new GameObject();
        _initialPosition = transform.position;
        Globals.CanControl = true;
    }

    //Método que atualiza a cada frame
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        //Se o pássaro foi lançado e a velocidade dele for menor que 0.2, faz com que a variável _timeSittingAround aumente.
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.2)
        {
            _timeSittingAround = _timeSittingAround + Time.deltaTime;
        }

        //Se o pássaro foi lançado, o texto de tutorial é excluido.
        if (_birdWasLaunched)
        {
            _textTutorial = GameObject.FindGameObjectWithTag("TextTutorial");
            Destroy(_textTutorial);
        }

        //Se o pássaro demorar muito tempo parado, reiniciar cena.
        if (Globals.IsAllMonsterDead == false && _timeSittingAround > 3.3)
        {
            Globals.Restart();
        }

        //Se o pássaro sair do cenário, reiniciar a cena.
        if (transform.position.y > _mapPositiveY || transform.position.y < _mapNegativeY ||transform.position.x > _mapPositiveX || transform.position.x < _mapNegativeX)
        {
            Globals.Restart();
        }
    }

    //Ao apertar o mouse  no pássaro, ele fica com a cor vermelha e aparece setas mostrando a direção que ele irá ser lançado.
    private void OnMouseDown()
    {   
        //Se a variável global CanControl estiver habilitada, a seta aparece.
        if (Globals.CanControl)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<LineRenderer>().enabled = true;
        } 
    }
    
    //Ao soltar o mouse faz com que o pássaro volte a ser branco, depois a variável directionToInitialPosition recebe a posição inicial do pássaro - a posição nova.
    //Depois, o .AddForce do RigidBody recebe a direção que o pássaro vai voar * o poder de lançamento definido anteriormente.
    //A variável _birdWasLaunched ativa dizendo que o pássaro foi lançado com sucesso e as setas são desativadas.
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        if(Globals.CanControl)
        {
            Vector2 DirectionToInitialPosition = _initialPosition - transform.position;
            GetComponent<Rigidbody2D>().AddForce(DirectionToInitialPosition * _launchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            _birdWasLaunched = true;
            Globals.CanControl = false;
            GetComponent<LineRenderer>().enabled = false;
        }
    }

    //Ao segurar o mouse faz com que o pássaro siga o cursor, transformando seu x e y no do cursor.
    private void OnMouseDrag() {
        //Se a variável CanControl estiver habilitada, pode arrastar o pássaro.
        if (Globals.CanControl)
        {
            //Seta a variável de x e y MousePosition com a posição do mouse.
            Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Se a posição arrastada do pássaro for maior do que a variável definida, o pássaro não vai mais pra trás.
            if (Vector3.Distance(MousePosition, Hook.position) > _maxDragDistance)
            {
                GetComponent<Rigidbody2D>().position = Hook.position + (MousePosition - Hook.position).normalized * _maxDragDistance;
            }
            else
            {
                GetComponent<Rigidbody2D>().position = MousePosition;
            }
            //transform.position = new Vector3(MousePosition.x, MousePosition.y);
        }
    }

    //Ao colidir com alguma coisa, troca o sprite do pássaro.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = BirdHit;
        GetComponent<Animator>().enabled = false;
    }

    //Ao sair da colisão, começa a Co-rotina que faz esperar um tempinho até voltar ao sprite normal.
    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(WaitToSpriteChange());
    }

    //Co-rotina responsável por voltar o pássaro ao normal.
    IEnumerator WaitToSpriteChange()
    {
        yield return new WaitForSeconds(_timeToSpriteChange);
        GetComponent<Animator>().enabled = true;
    }
}
