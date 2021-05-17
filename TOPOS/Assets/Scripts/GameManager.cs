using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float tiempo;
    public GameObject topo;
    Topos[] topos;
    public float salir;

    void Start()
    {
        topos = topo.GetComponentsInChildren<Topos>();
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        NumAleatorio(salir);
        if (tiempo <= 60)
        {
            if (salir > 95f)
            {
                topos[Random.Range(0, topos.Length)].TopoVisible();
            }
        }
    }

    float NumAleatorio(float num)
    {
        salir = Random.Range(0, 100);

        return salir;
    }
}
