using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToposBehaviour : MonoBehaviour
{
    public GameObject topo;
    public float timer;
    public Transform visible;
    public Transform oculto;
    public bool esVisible;
    public float tiempoVisible;
    public int numRandom;
    void Start()
    {
        Randomizador();
    }

    // Update is called once per frame
    void Update()
    {
        int num = 3;
        timer += Time.deltaTime;

        if (numRandom >= 40)
        {
            topo.transform.localPosition = visible.localPosition;
            timer = 0f;
            esVisible = true;
        }

        if (esVisible == true)
        {
            tiempoVisible += Time.deltaTime;
            if (tiempoVisible >= 2)
            {
                topo.transform.localPosition = oculto.localPosition;
                numRandom = 0;
                esVisible = false;
                tiempoVisible = 0;
            }
        }

        if(timer>num && esVisible == false)
        {
            Randomizador();
            num = num + 3;
        }
    }

    void Randomizador()
    {
        numRandom = Random.Range(0, 50);
    }
}
