﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float volumenMusica;
    public GameObject manager;
    public TextMeshProUGUI cronoText;
    public float tiempo;
    public GameObject topo;
    Topos[] topos;
    public float salir = 0;
    public TextMeshProUGUI puntosText;
    public int puntuacion;
    public CanvasGroup gameOver;
    float duracionAlfa;
    public GameObject gameOverActivo;
    public AudioSource musica;
    public AudioSource sonidoGameOver;
    public AudioSource sonidoTopoSalir;
    public AudioSource sonidoTopoGolpe;


    private void Awake()
    {
        gameOverActivo.SetActive(false);
    }

    void Start()
    {
        manager.SetActive(false);
        gameOver.alpha = 0;
        topos = topo.GetComponentsInChildren<Topos>();
    }

    void Update()
    {
        musica.volume = volumenMusica;
        tiempo -= Time.deltaTime;
        NumAleatorio(salir);
        if (tiempo >= 0)
        {
            if (salir > 97f)
            {
                topos[Random.Range(0, topos.Length)].TopoVisible();
                sonidoTopoSalir.Play();
            }
        }
        else
        {
            GameOver();
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
        duracionAlfa = 0;
        manager.SetActive(false);
        cronoText.text = Tiempo(tiempo);
        puntosText.text = MostrarPuntos(puntuacion);
    }

    public void Reload()
    {
        manager.SetActive(true);
        puntuacion = 0;
        salir = 0;
        tiempo = 60;
        duracionAlfa = 0;
    }

    public void GameOver()
    {
        gameOverActivo.SetActive(true);
        duracionAlfa += Time.deltaTime;
        gameOver.alpha = duracionAlfa;
        if (gameOver.alpha >= 1)
        {
            gameOver.alpha = 1;
            manager.SetActive(false);
        }
    }

    public void SetVolumenMusica(float vol)
    {
        volumenMusica = vol;
    }

    public void Cerrar()
    {
        Application.Quit();
    }
}
