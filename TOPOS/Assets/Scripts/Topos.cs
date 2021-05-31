using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topos : MonoBehaviour
{
    public float posOculto;
    public float posVisible;
    public bool esVisible;
    public int puntos;
    Vector3 altura;
    float velocidad = 2f;
    public float tiempoVisible;
    public GameManager funcion;
    public AudioSource toposSonidos;
    public AudioClip golpeTopo;
    public AudioClip irseTopo;

    void Awake()
    {
        TopoOculto();
        transform.localPosition = altura;
        esVisible = false;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, altura, velocidad * Time.deltaTime);

        tiempoVisible -= Time.deltaTime;

        GolpearTopo();
    }

    public void GolpearTopo()
    {
        if (tiempoVisible < 0)
        {
            TopoOculto();
            esVisible = false;
        }

        else if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("Topo") && (hitInfo.collider.gameObject == this.gameObject) && (esVisible == true))
                {
                    TopoOculto();
                    esVisible = false;
                    funcion.AddPoints(puntos);
                    toposSonidos.PlayOneShot(golpeTopo);
                }

                if (hitInfo.collider.tag.Equals("PowerUpTime") && (hitInfo.collider.gameObject == this.gameObject) && (esVisible == true))
                {
                    funcion.SumarTiempo(10);
                    TopoOculto();
                    esVisible = false;
                }

                if (hitInfo.collider.tag.Equals("PowerUpPoints") && (hitInfo.collider.gameObject == this.gameObject) && (esVisible == true))
                {
                    funcion.DoblarPuntuacion();
                    TopoOculto();
                    esVisible = false;
                }

                if (hitInfo.collider.tag.Equals("PowerUpBomb") && (hitInfo.collider.gameObject == this.gameObject) && (esVisible == true))
                {
                    funcion.QuitarPuntos(50);
                    TopoOculto();
                    esVisible = false;
                }
            }
        }
    }

    public void TopoOculto()
    {
        altura = new Vector3(transform.localPosition.x, posOculto, transform.localPosition.z);
    }

    public void TopoVisible()
    {
        altura = new Vector3(transform.localPosition.x, posVisible, transform.localPosition.z);
        esVisible = true;
        tiempoVisible = 2f;
    }
}
