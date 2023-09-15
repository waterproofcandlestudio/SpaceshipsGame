using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Con "velocidadActual" recojo la velocidad q uso en cada momento, para poder variar entre la
    //      velocidad normal == "velocidadMovimiento"
    //      correr           == "velocidadCorrer"
    public float velocidadActual;
    public float velocidadMovimiento = 5.0f;

    //  Uso estas variables "x" e "y" para coger la velocidad para...
    //      x == rotar la cámara al darle a "A" o "D"
    //      y == moverse hacia delante
    //  Tmb las uso en el blend tree del "playerController" para según la posición en estos ejes q haga diferentes animaciones
    public float x, y;

    public AudioClip explosion;


    public int health = 3;
    public Text healthCanvas;

    public GameObject explosionParticle;

    private void ShowHealth()
    {
        healthCanvas.text = health.ToString();
    }

    public void MinusHealth()
    {
        health--;
    }

    // Update is called once per frame
    void Update()
    {
        // Hago q el personaje rote
        transform.Translate(x * Time.deltaTime * velocidadActual, 0, 0);
        // Hago q se desplace
        transform.Translate(0, y * Time.deltaTime * velocidadActual, 0);

        // Cojo el input de los ejes horizontal y vertical con las variables "x" e "y"
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        ShowHealth();
        if (health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //Enemy enemy = collider.GetComponent<Enemy>();
        if (collider.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(explosion, transform.position);

            health--;
            healthCanvas.text = health.ToString();
            if (health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Game Over");
            }
        }
        if (collider.tag == "EnemyBullet")
        {
            AudioSource.PlayClipAtPoint(explosion, transform.position);
            Instantiate(explosionParticle, transform.position, transform.rotation);

            health--;
            healthCanvas.text = health.ToString();
            if (health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Game Over");
            }
        }
    }
}
