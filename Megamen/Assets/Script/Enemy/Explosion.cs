using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   public void DestroyObject() // metodo responsavel para destruir a anima��o da explos�o
    {
        Destroy(gameObject); // destroi o objeto ( explos�o )
    }
}
