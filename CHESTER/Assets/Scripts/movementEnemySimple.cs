using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEnemySimple : MonoBehaviour
{
    //Variables
    RaycastHit hit;
    public float distancia;
    public LayerMask layerM;
    public bool right;
    public float speed;

    RaycastHit hit2;
    public Vector3 v3;


    // Update is called once per frame
    void Update()
    {
        //Si right es falso, cambiara de direccion
        if (right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Physics2D.Raycast(transform.position, transform.right, distancia, layerM))
        {
            right = !right;
        }
        //Si detecta la pared, gira
        if (Physics2D.Raycast(transform.position + v3, transform.up * -1, distancia, layerM))
        {

        }
        else
        {
            right = !right;
        }
    }

    //  Dibujamos 2 lineas para detectar la pared y el suelo
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * distancia);
        Gizmos.DrawRay(transform.position + v3, transform.up * -1 * distancia);

    }
}
