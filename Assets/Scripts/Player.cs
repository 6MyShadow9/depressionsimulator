using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : mover
{

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");  

        UpdateMotor(new Vector3(x,y,0));
    }
}
