using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(rayPoint.position, Vector2.right * transform.localScale, rayDistance);
        if (grabCheck.collider != null && grabCheck.collider.tag == "Caja")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = grabPoint;
                grabCheck.collider.gameObject.transform.position = grabPoint.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }     
    }
}
