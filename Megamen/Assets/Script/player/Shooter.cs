using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bullet; // como utilizamos parte do script bullet, chamamos ele.
    public float fireRate = 0.2f; // podemos atirar a cada 0.2 segundos.
    public Transform spawnBullet; // para saber a posição do spawn bullet
    [SerializeField]
    private bool canShoot = true; // posso atirar? por padrao sim

    // para audio do tiro

    public AudioSource audioSource; // onde executa o som
    public AudioClip shootClip; // audio do tiro

    public void Start()
    {
        audioSource = GetComponent<AudioSource>(); // armazena o audio na variavel
            
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && canShoot) // seprescionar o botao de atirar e posso atirar, ira atirar
        {
            StartCoroutine(SpawnBullet());//iniciar a coroutine
        }
    }
    IEnumerator SpawnBullet() // coroutine, evita a perda de desempenho
    {
        canShoot = false; // nao pode atirar ate passar 0.2 segundos
        Instantiate(bullet, spawnBullet.position, transform.rotation); // isntancia tiro na posição do spawn
        audioSource.PlayOneShot(shootClip); // reproduz o audio do tiro uma vez

        yield return new WaitForSeconds(fireRate); // espera o tempo declarado, que foi 0.2 seg
        canShoot = true; // apos esperar o tempo pode atirar novamente
    }
}
