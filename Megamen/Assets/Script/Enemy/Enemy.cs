using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //variaveis
    public float enemySpeed = 4f; // velocidade do inimigo
    public int health = 2; // quantidade de vida do inimigo
    private Transform playerPosition; // parar saber onde esta o jogador


    // explosão

    public GameObject explosion; // onde vai ser associado o prefab da explosao
    
    void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>(); // a variavel encontra o objeto com a tag player e pega seu transform
    }

  
    void Update()
    {
        if (transform.position.x < playerPosition.position.x) // se a posição do inimigo for menor que a do player, o inimigo fica por padrao virando pra esquerda
        {
            transform.right = Vector2.left; // roda o inimigo para a esquerda
        }

        else
        {
            transform.right = Vector2.right; // roda o inimigo para a direita
        }

        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemySpeed * Time.deltaTime); // faz o inimigo se mover de um ponto ao outro, no caso o inmigo vai ate o player, tempo mais fluido.

        if (health<=0) // se a vida do inimigo for 0 ou menor que zero ele deve destruir
        {
            Instantiate(explosion, transform.position, Quaternion.identity); // instanciar a explosão na mesma posição do inimigo, sem alterar as rotações do obj
            Destroy(gameObject); // destroi o inimigo
        }
    }

    public void TakeDamage( int damage) // aonde o inimigo recebe o dano
    {
        health -= damage; // igual a health - damage
    }
}
