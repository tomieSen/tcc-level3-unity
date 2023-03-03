using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 direction = new(); //andar
    Vector3 aux = new(), lookPosition = new(); //auxiliar no pulo e gravidade
    public float speed, jumpSpeed;
    public bool jump = false;
    public CharacterController body;
    public GameObject model;

    void Start()
    {
        body = GetComponent<CharacterController>();
    }

    void Update()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(raio, out hit, 100)){
            //print(hit.transform.position);
            lookPosition = hit.point;
            lookPosition.y = transform.position.y;
            model.transform.forward = (lookPosition - transform.position).normalized;
        }
        direction = Input.GetAxisRaw("Vertical") * speed * model.transform.forward;
        jump = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        aux.y -= 10 * Time.deltaTime; //gravidade cal
        direction.y = aux.y;
        if (body.isGrounded)
        {
            direction.y = 0;
            if (jump)
            {
                direction.y = jumpSpeed;
            }
            aux.y = direction.y;
        }

        body.Move(direction * Time.deltaTime);
    }
}