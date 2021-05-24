using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   public void DestroyObject() // metodo responsavel para destruir a animação da explosão
    {
        Destroy(gameObject); // destroi o objeto ( explosão )
    }
}
