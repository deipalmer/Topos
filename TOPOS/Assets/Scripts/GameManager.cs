using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float volumenM;
    float volumenSFX;
    public float pausa;
    public float tiempoBonus;
    bool doblePuntuacion = false;
    public bool tiempoPausado;
    public GameObject manager;
    public TextMeshProUGUI cronoText;
    public float tiempo;
    public GameObject topo;
    public Topos funcionesTopo;
    Topos[] topos;
    public int salir = 0;
    public TextMeshProUGUI puntosText;
    public TextMeshProUGUI puntosTextGameOver;
    public int puntuacion;
    public CanvasGroup gameOver;
    float duracionAlfa;
    public GameObject gameOverActivo;
    public AudioSource sonidos;
    public AudioSource musica;
    public AudioClip salirTopo;
    public AudioClip finPartida;
    public AudioClip empiezaPartida;


    private void Awake()
    {
        gameOverActivo.SetActive(false);
        tiempoPausado = false;
    }

    void Start()
    {
        manager.SetActive(false);
        gameOver.alpha = 0;
        topos = topo.GetComponentsInChildren<Topos>();
    }

    void Update()
    {
        if (doblePuntuacion == true)
        {
            tiempoBonus += Time.deltaTime;
        }

        if (tiempoBonus >= 5f)
        {
            doblePuntuacion = false;
            tiempoBonus = 0f;
        }

        tiempo -= Time.deltaTime;
        salir = Random.Range(0, 100);
        
        if (tiempo >= 0)
        {
            if (salir > 96f)
            {
                topos[Random.Range(0, topos.Length)].TopoVisible();
                sonidos.PlayOneShot(salirTopo);
            }
        }
        else
        {
            GameOver();
            tiempo = 0;
        }
        cronoText.text = Tiempo(tiempo);
        puntosText.text = MostrarPuntos(puntuacion);
        puntosTextGameOver.text = MostrarPuntos(puntuacion);

        musica.volume = volumenM;
        sonidos.volume = volumenSFX;
    }

    string Tiempo(float total)
    {
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;

        return minutos.ToString("00") + (" : ") + segundos.ToString("00");
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
        duracionAlfa -= Time.deltaTime;
        if (duracionAlfa <= 0)
        {
            duracionAlfa = 0;
        }
    }

    public void GameOver()
    {
        gameOverActivo.SetActive(true);
        duracionAlfa += Time.deltaTime;
        gameOver.alpha = duracionAlfa;
        musica.PlayOneShot(finPartida);
        if (gameOver.alpha >= 1)
        {
            gameOver.alpha = 1;
            manager.SetActive(false);
        }
    }

    public void Cerrar()
    {
        Application.Quit();
    }

    public void QuitarPuntos(int valor)
    {
        puntuacion -= valor;

        if (puntuacion < 0)
        {
            puntuacion = 0;
        }
    }

    public void SumarTiempo(int valor)
    {
        tiempo += valor;
    }

    public void DoblarPuntuacion()
    {
        tiempoBonus = 0f;
        doblePuntuacion = true;
    }

    public void AddPoints(int valor)
    {
        if (doblePuntuacion == false)
        {
            puntuacion += valor;
        }

        if (doblePuntuacion == true)
        {
            puntuacion += valor * 2;
        }
    }

    public void VolumenMusica(float vol)
    {
        volumenM = vol;
    }

    public void VolumenSFX(float vol)
    {
        volumenSFX = vol;
    }
}
