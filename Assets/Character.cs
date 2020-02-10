using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private State currentState;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
    setState(new BaseState(this));
        
    }


    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
    }
    public void setState(State state)
    {

        if (state.Gate()) { 
        if (currentState != null)
            currentState.onStateExit();

        currentState = state;
        gameObject.name = "Cube - " + state.GetType().Name;
        if (currentState != null)
            currentState.onStateEnter();
        }
    }
}
