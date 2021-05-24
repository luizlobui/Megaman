using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //variaveis

    public Transform player; // pega a posi��o do player
    public Vector3 offset; // deslocamento da camera
       void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // pega a posi��o do jogador e adiciona deslocamento no eixo x
    }
}
