using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topos : MonoBehaviour
{
    public float oculto;
    public float visible;
    Vector3 altura;
    float velocidad = 3f;
    public float tiempoVisible;
    public int puntos = 0;

    void Awake()
    {
        TopoOculto();
        transform.localPosition = altura;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, altura, velocidad * Time.deltaTime);

        tiempoVisible -= Time.deltaTime;

        if (tiempoVisible < 0)
        {
            TopoOculto();
        }
    }

    public void TopoOculto()
    {
        altura = new Vector3(transform.localPosition.x, oculto, transform.localPosition.z);
    }

    public void TopoVisible()
    {
        altura = new Vector3(transform.localPosition.x, visible, transform.localPosition.z);
        tiempoVisible = 2f;
    }
}
