﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topos : MonoBehaviour
{
    public float posOculto;
    public float posVisible;
    Vector3 altura;
    float velocidad = 3f;
    public float tiempoVisible;

    void Awake()
    {
        TopoOculto();
        transform.localPosition = altura;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, altura, velocidad * Time.deltaTime);

        tiempoVisible -= Time.deltaTime;

        GolpearTopo();
    }

    public void GolpearTopo()
    {
        if (tiempoVisible <= 0)
        {
            TopoOculto();
        }

        else if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("Topo") && (hitInfo.collider.gameObject == this.gameObject))
                {
                    TopoOculto();
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
        tiempoVisible = 1.5f;
    }
}
