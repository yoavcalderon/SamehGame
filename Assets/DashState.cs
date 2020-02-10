using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{

    private Vector3 movement;
    private CharacterController controller;
    private float rollspeed = 100;

    //generate constructor
    public DashState(Character character) : base(character)
    {
    }

    //We took our virtual method from state class, this will not always be implemented by default, it will act similar to the start function
    public override void onStateEnter()
    {
        controller = character.GetComponent<CharacterController>();
        movement = movement.normalized;
        rollspeed = 100f;
    }
    public override bool Gate()
    {
        movement = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if(movement!= Vector3.zero)
        {
            return true;
        }
        return false;
    }

    public override void Tick()
    {
        controller.Move(movement * rollspeed * Time.deltaTime);
        rollspeed -= rollspeed * 10 * Time.deltaTime;
        if (rollspeed < 5f)
        {
            character.setState(new BaseState(character));
        }

    }

}

