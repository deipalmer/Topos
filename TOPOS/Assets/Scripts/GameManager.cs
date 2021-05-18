using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI cronoText;
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

        cronoText.text = Tiempo(tiempo);
    }

    float NumAleatorio(float num)
    {
        salir = Random.Range(0, 100);

        return salir;
    }

    string Tiempo(float total)
    {
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        int miliSegundos = (int)tiempo % 3600;

        return minutos.ToString("00") + (" : ") + segundos.ToString("00") + (" : ");
    }

    public void Cerrar()
    {
        Application.Quit();
    }
}
