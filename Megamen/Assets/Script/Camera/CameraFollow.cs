using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //variaveis

    public Transform player; // pega a posição do player
    public Vector3 offset; // deslocamento da camera
       void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // pega a posição do jogador e adiciona deslocamento no eixo x
    }
}
