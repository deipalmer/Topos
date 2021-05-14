using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float tiempo;
    public GameObject topo;
    Topos[] topos;
    public float salir = 0f;

    // Start is called before the first frame update
    void Start()
    {
        topos = topo.GetComponentsInChildren<Topos>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo <= 60)
        {
            salir = Random.Range(0, 100);
            if (salir > 95f)
            {
                topos[Random.Range(0, topos.Length)].TopoVisible();
                salir = 0f;
            }
        }
    }
}
