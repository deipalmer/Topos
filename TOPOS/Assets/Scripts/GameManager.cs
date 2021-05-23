using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject manager;
    public TextMeshProUGUI cronoText;
    public float tiempo;
    public GameObject topo;
    Topos[] topos;
    public float salir = 60;
    public TextMeshProUGUI puntosText;
    public int puntuacion;

    void Start()
    {
        topos = topo.GetComponentsInChildren<Topos>();
    }

    void Update()
    {
        tiempo -= Time.deltaTime;
        NumAleatorio(salir);
        if (tiempo >= 0)
        {
            if (salir > 97f)
            {
                topos[Random.Range(0, topos.Length)].TopoVisible();
            }
        }
        else
        {
            tiempo = 0;
        }

        cronoText.text = Tiempo(tiempo);
        puntosText.text = MostrarPuntos(puntuacion);
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

        return minutos.ToString("00") + (" : ") + segundos.ToString("00");
    }

    public void Cerrar()
    {
        Application.Quit();
    }

    public void AddPoints(int valor)
    {
        puntuacion += valor;
    }

    public string MostrarPuntos(int puntuacion)
    {
        return puntuacion.ToString("0000");
    }

    public void VueltaMenu()
    {
        manager.SetActive(true);
        puntuacion = 0;
        salir = 0;
        tiempo = 0;
        manager.SetActive(false);
        cronoText.text = Tiempo(tiempo);
        puntosText.text = MostrarPuntos(puntuacion);
    }
}
