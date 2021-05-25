using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    Topos variables;
    bool esVisible;
    Vector3[] altura;
    float velocidad = 3f;
    public float tiempoVisible;
    public GameObject[] topos;
    Vector3[] ubicacion;

    void Awake()
    {
        PowerUpOculto();
        transform.localPosition = ubicacion[0];
        esVisible = false;
    }

    void Update()
    {
        for (int i = 0; i <= topos.Length; i++)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, altura[0], velocidad * Time.deltaTime);
        }

        tiempoVisible -= Time.deltaTime;

        GolpearPowerUp();
    }

    public void GolpearPowerUp()
    {
        if (tiempoVisible < 0)
        {
            PowerUpOculto();
            esVisible = false;
        }

        else if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("PowerUp") && (hitInfo.collider.gameObject == this.gameObject) && (esVisible == true))
                {
                    PowerUpOculto();
                    esVisible = false;
                }
            }
        }
    }

    public void PowerUpOculto()
    {
        for (int i = 0; i <= topos.Length; i++)
        {
            ubicacion[i] = new Vector3(topos[i].transform.localPosition.x, -3f, topos[i].transform.localPosition.z);
        }
    }

    public void PowerUpVisible()
    {
        for(int i=0;i<=topos.Length;i++)
        {
            ubicacion[i] = new Vector3(topos[i].transform.localPosition.x, 3f,topos[i].transform.localPosition.z);
            altura[i] = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        esVisible = true;
        tiempoVisible = 2f;
    }
}
