using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public float speed = 7f; //velocidade da movimentação do personagem

    private Vector2 direction = Vector2.zero; //movendo o personagem 2D e a movimentação inicial do jogar é zero.
    private Rigidbody2D rb; // Armazenar o rigidbody do programa.

    //pulo
    public float jumpForce = 12f; // força do pulo
    private bool isJump = false; // checa se o personagem esta pulando, por padrao ele nao esta.

    //checar a colisão do personagem no chão
    public Transform foot; //para saber a posição do pé do personagem
    public float collisionRadius = 0.25f; // tamanho do colisor do pe
    public LayerMask layerGround; // pega a layer que criamo o chao
    [SerializeField]
    private bool isOnFloor = false; // checa se esta no chao, e por padrao nao esta.

    // animação

    private Animator anim; // armazena o animator do personagem player

    // audio do pulo

    private AudioSource audioSource; // audio do source
    public AudioClip jumpAudio;


// funções
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //pega o compenente rigidbody do obj (player) e coloca na variavel.
        anim = GetComponent<Animator>(); // recebe o componente animador do objeto

        audioSource = GetComponent<AudioSource>(); // recebe o componente audio source do objeto
    }
   
    void Update() // executa a todo momento e interfere no desempenho.
    {

        GroundCheck(); // chama o metodo colisor.

        if(Input.GetKeyDown(KeyCode.Space) && isOnFloor) // se o jogador apertar espaço o pesonagem esta pulando, e so pula se tocar o chao dnv
        {
            isJump = true ; // o personagem esta pulando
            audioSource.PlayOneShot(jumpAudio); // toca o audio

            }
        anim.SetBool("jumping", isOnFloor == false); // o parametro de pular vai ser vdd quando o personagem nao esta no chao
        anim.SetBool("shooting", Input.GetButton("Fire1")); // o parametro de atirar vai ser vdd quando mandarmos o personagem atirar
        anim.SetBool("running", Input.GetAxisRaw("Horizontal") != 0); //parametro de correr é vdd quando o valor do eixo x é diferente de 0
    }
    private void FixedUpdate() // executa em um intervalo de tempo fixo e nao interfere no desempenho.
    {
        Move(Input.GetAxisRaw("Horizontal")); // GetAxisRaw utiliza eixos que já são definidos pela engine no caso horizontal, controla esquerda e direita.
        if (isJump)
        {
            isJump = false; // para conseguir checar o pulo depois
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // vai mover o nosso personagem para cima
        }
    }

    void Move(float move) // movimenta o personagem. "float move" recebe o valor do comando (seta direita e esquerda)
    {
        // se o valor recebido for positivo, mover para direita.

        if(move > 0)
        {
            direction = Vector2.right; // =1
        }

        if (move < 0 )
        {
            direction = Vector2.left; // =-1
        }

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); // movimentar o personagem. pega o valor do eixo x (esq ou dire) e o eixo y permanece igual.

        if (move == 0) //se o personagem esta parado.
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        transform.right = direction; // o personagem esta virado por padrão para a direita, vai flipar o personagem de acordo com o lado.
    }

    void GroundCheck() // checar se o personagem esta no chao
    {
        isOnFloor = Physics2D.OverlapCircle(foot.position, collisionRadius, layerGround); // checa se o colisor esta colidindo em uma area circular em (posição.tamanho.camada atual).
    }

}
