using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // velocidade do tiro
    private Rigidbody2D rb;

    //inimigo

    public int damage = 1; // quantidade de dano que o tiro causa
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // o tiro vai na direção que o personagem está virado, o personagem por padrao estara virado para a direita
        Destroy(gameObject, 2f); // destroi o tiro dps de 2 segundos
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // responsavel pela interação entre os triggers e colliders. evento dos triggers
    {
        if (collision.CompareTag("Enemy")) // se a bala colidir com o inimigo
        {
            collision.GetComponent<Enemy>().TakeDamage(damage); // pega o script enemy do obj e passa pelo metodo TakeDamage o valor da variavel
        }

        Destroy(gameObject); // destroi os tiros ao entrar em contato com qualquer coisa
    }
}