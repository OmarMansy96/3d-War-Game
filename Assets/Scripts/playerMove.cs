using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public GameObject tankTower, tankTowerPipe;
    float rotation_Speed = 40f;
    float rotaion_Joystick_Speed = 10f;
    float moveSpeed = 15f;
    public Joystick moving_joystick,selection_JoyStick;
    Vector3 movement;
    Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    private float HorizontalAxis()
    {

        var h = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(h) > 0)
        {
            return h;

        }
        else
        {
            return moving_joystick.Horizontal;
        }
    }
    private float VerticalAxis()
    {
        var v = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(v) > 0)
        {
            return v;
        }
        else
        {
            return moving_joystick.Vertical;
        }
    }

    void Update()
    {
        movement.z = VerticalAxis();
        movement.y = HorizontalAxis();
       
        transform.Translate(new Vector3(0, 0, movement.z * moveSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(0, movement.y * rotation_Speed * Time.deltaTime, 0));

        TankTowerVectors();

    }

   public void TankTowerVectors()
    {
        if (Input.GetKey(KeyCode.RightArrow)||selection_JoyStick.Horizontal > 0)
        {
            tankTower.transform.Rotate(new Vector3(0, rotaion_Joystick_Speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || selection_JoyStick.Horizontal < 0)
        {
            tankTower.transform.Rotate(new Vector3(0, -rotaion_Joystick_Speed * Time.deltaTime, 0));

        }
        if (Input.GetKey(KeyCode.UpArrow) || selection_JoyStick.Vertical > 0)
        {
            tankTowerPipe.transform.Rotate(new Vector3(-rotaion_Joystick_Speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.DownArrow) || selection_JoyStick.Vertical < 0)
        {
            tankTowerPipe.transform.Rotate(new Vector3(rotaion_Joystick_Speed * Time.deltaTime, 0, 0));
        }
    }
 
}
