using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float velocidad = 5f;

    public float fuerzaSalto = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    private bool enSuelo;
    private Rigidbody2D rb;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        //Todo esto se encarga del salto, tanto de detectar si est� tocando el suelo, como de ejecutar el salto sino
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }

        animator.SetBool("enSuelo", enSuelo);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}
