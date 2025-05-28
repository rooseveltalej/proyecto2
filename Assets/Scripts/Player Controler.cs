using System;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float velocidad = 5f;

    [SerializeField] private float fuerzaSalto = 5f;
    public float longitudRaycast = 0.1f;
    
    private bool enSuelo;
    private bool salto;

    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private LayerMask capaSuelo;

    [SerializeField] private int saltosExtraRestantes;
    [SerializeField] private int saltosExtra;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //Este vendr�a a ser el movimiento horizontal del jugador
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        //Este es para actualizar la animacion del jugador 
        animator.SetFloat("movement", velocidadX * velocidad);


        if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        Vector3 posicion = transform.position;
        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);

        
        // Code para detectar el salto

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, capaSuelo);

        if (enSuelo) {
            saltosExtraRestantes = saltosExtra;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto = true;
        }        

    }

    private void FixedUpdate()
    {
        Movimiento(salto);
        salto = false;
    }

    private void Movimiento(bool salto)
    {
        if (salto) {
            if (enSuelo)
            {
                Salto();
            }
            else
            {
                if (salto && saltosExtraRestantes > 0) {
                    Salto();
                    saltosExtraRestantes -= 1;
                }
            }
        }
    }

    private void Salto()
    {
        rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        animator.SetBool("enSuelo", enSuelo);
        salto = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
