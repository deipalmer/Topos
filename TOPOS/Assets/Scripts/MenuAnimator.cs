using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    public GameObject menuDesaparecer;
    public GameObject menuAparecer;
    public float ubicacionDesaparecerX;
    public float ubicacionDesaparecerY;
    float duracionDesaparecer = 0.5f;
    float ubicacionAparecerX = 0;
    float ubicacionAparecerY = 0;
    float duracionAparecer = 0.5f;
    public Vector3 escalaAparecer;
    public Vector3 escalaDesparecer;
    public void DesaparecerDeslizando()
    {
        LeanTween.moveLocalX(menuDesaparecer, ubicacionDesaparecerX, duracionDesaparecer);
        LeanTween.moveLocalY(menuDesaparecer, ubicacionDesaparecerY, duracionDesaparecer);
    }

    public void AparecerDeslizando()
    {
        LeanTween.moveLocalX(menuAparecer, ubicacionAparecerX, duracionAparecer);
        LeanTween.moveLocalY(menuAparecer,ubicacionAparecerY,duracionAparecer);
    }

    public void DesaparecerEscala()
    {
        LeanTween.scale(menuDesaparecer, escalaDesparecer, duracionDesaparecer);
    }

    public void AparecerEscala()
    {
        LeanTween.scale(menuAparecer, escalaAparecer, duracionAparecer);
    }
}
