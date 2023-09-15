using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //      velocidad normal == "velocidadMovimiento"
    public float velocidadMovimiento = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Hago q el personaje rote
        transform.Translate(0, 0, -velocidadMovimiento * Time.deltaTime);
    }
}
