using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;


public class CamaraControler : MonoBehaviour
{
    public Transform objetivo;
    public float velocidadCamara = 0.02f;
    public Vector3 desplazamiento;

    private void LateUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + desplazamiento;

        Vector3 posicionSuavidaza = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);
        transform.position = posicionSuavidaza;
    }
}
