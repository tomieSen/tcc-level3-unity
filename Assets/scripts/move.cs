using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 direction = new();
    Vector3 aux = new(), lookposition =new();
    float rotY = 0;
    public float velocidade, girar;
    public CharacterController characterController;
    public Transform go;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(raio, out hit)){
            lookposition = hit.transform.position;
            lookposition.y = transform.position.y;
        }
        direction = Input.GetAxis("Vertical") * velocidade * transform.forward;
        rotY = (Input.GetAxis("Horizontal") * girar);
    }

    private void FixedUpdate()
    {
        aux.y -= 5 * Time.deltaTime;
        direction.y = aux.y;
        //transform.Rotate(0, rotY, 0);
        go.LookAt(lookposition);

        characterController.Move(direction*Time.deltaTime);
    }
}