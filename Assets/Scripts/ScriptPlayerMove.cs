using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerMove : MonoBehaviour
{
    /*Rigidbody rb;
    public float movementSpeed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float rotationSpeed = 200.0f;*/
    Rigidbody rb;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    private PlayerMotor motor;


    void Start()
    {
        motor = GetComponent<PlayerMotor>();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;



        motor.Move(_velocity);
        



        // Rotate Mouse FPS
        /* float _yRotate = Input.GetAxisRaw("Mouse X");

         Vector3 _rotation = new Vector3(0f, _yRotate, 0f) * lookSensitivity;

         motor.Rotate(_rotation);

         float _xRotate = Input.GetAxisRaw("Mouse Y");

         Vector3 _cameraRotation = new Vector3(_xRotate, 0f, 0f) * lookSensitivity;

         motor.RotateCamera(_cameraRotation);*/





        //Move RPG
        /* transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
         transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);

         if (Input.GetKey(KeyCode.Space))
         {
             Vector3 atas = new Vector3(0, 10, 0);
             rb.AddForce(atas * jumpSpeed);
         }*/
    }

}
