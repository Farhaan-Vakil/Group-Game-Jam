using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 1;

    private Vector3 scaleChange, positionChange;
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    private bool gravity = false;
    public bool isGrounded = false;

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            gravity = !gravity;

            if (gravity == true)
            {
                Physics.gravity = new Vector3(0, 9.8F, 0);
                transform.rotation = Quaternion.Euler(new Vector3(-180, 0, 0));

                //rb.AddForce(-2 * Physics.gravity, ForceMode.Acceleration);
            }
            if (gravity == false)
            {
                Physics.gravity = new Vector3(0, -9.8F, 0);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (gravity == false)
            {
                rb.AddForce(0, 10f, 0, ForceMode.Impulse);
            }
            if(gravity == true)
            {
                rb.AddForce(0, -10f, 0, ForceMode.Impulse);
            }

            isGrounded = false;
        }
        //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Camera.main.transform);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Camera.main.transform);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed, Camera.main.transform);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Camera.main.transform);

        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        positionChange = new Vector3(0.0f, -0.005f, 0.0f);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localScale += scaleChange;
            transform.position += positionChange;

            if (transform.localScale.y < 0.1f || transform.localScale.y > 1.0f)
            {
                scaleChange = -scaleChange;
                positionChange = -positionChange;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localScale -= scaleChange;
            transform.position -= positionChange;

            if (transform.localScale.y < 0.1f || transform.localScale.y > 1.0f)
            {
                scaleChange = scaleChange;
                positionChange = positionChange;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
