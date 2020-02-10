using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : State
{
    //We need to think which state we will need for the base state
    //    firstly, a charachter controller- a built in function of unity to recognize a that the object should respond to rigidbody and physics
    private CharacterController controller;
    //now we need a vector that shows where we are and where we want to go in the gameworld, it does this by using x,y,z cooridnates respectively
    //and moving us toward the user input which translates to 1 0 and -1 for each of our coordinates
    private Vector3 movement;
    //generate constructor
    public BaseState(Character character) :base(character)
    {
    }

    //We took our virtual method from state class, this will not always be implemented by default, it will act similar to the start function
    public override void onStateEnter()
    {
    //now we insert a refrecnce to the controller found in the charachter class so we may use it later    
        controller = character.GetComponent<CharacterController>();
    }

    public override void Tick()
    {
        //now is the time where we recive info from the player ( our input)
        //and use getaxisraw which delivers the 1 0 -1 we previously mentioned to populate the vector and normalize so that our charachter moves at equal speed across the board 
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movement = movement.normalized;
        //now we use the controller refrence we placed in onstartenter together with the movement we populated to tell the controller what to do
        controller.Move(movement * character.moveSpeed * Time.deltaTime);
        if (Input.GetButton("Jump"))
        {
            character.setState(new DashState(character));
        }
    }

}

