﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;
    public CharacterController controller;

    public float gravity = -9.81f;
    public float moveSpeed = 5f ;
    public float jumpSpeed = 5f;

    public float yVelocity = 0;

    private bool[] inputs;

    public void Start()
    {
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;
        moveSpeed *= Time.fixedDeltaTime;
        jumpSpeed *= Time.fixedDeltaTime;
    }
    public void Initalize(int _id, string _username)
    {
        id = _id;
        username = _username;
    

        inputs = new bool[5];
    }
    public void FixedUpdate()
    {
        Vector2 _inputDirection = Vector2.zero;
        if (inputs[0])
        {
            _inputDirection.y+= 200;
        }
        if (inputs[1])
        {
            _inputDirection.y -= 200;
        }
        if (inputs[2])
        {
            _inputDirection.x -= 200;
        }
        if (inputs[3])
        {
            _inputDirection.x += 200;
        }

        Move(_inputDirection);
    }

    private void Move(Vector2 _inputDirection)
    {
       

        Vector3 _moveDirection = transform.right * _inputDirection.x + transform.forward * _inputDirection.y;
        _moveDirection *= moveSpeed;

        if (controller.isGrounded)
        {
            yVelocity = 0f;
            if (inputs[4])
            {
                yVelocity = jumpSpeed;
            }
        }

     
        _moveDirection.y = yVelocity;

        controller.Move(_moveDirection);

        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }

    private void Move(Vector3 _inputDirection)
    {


        Vector3 _moveDirection = transform.right * _inputDirection.x + transform.forward * _inputDirection.y + transform.forward * _inputDirection.z;
        yVelocity = 0f;

        yVelocity = _inputDirection.y;

        _moveDirection.y = yVelocity;

        controller.Move(_moveDirection);




        _moveDirection.y = yVelocity;

        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }

    public void SetInput(bool[] _inputs, Quaternion _rotation)
    {
        inputs = _inputs;
        transform.rotation = _rotation;
    }

    public void SetPosition(Vector3 _position)
    {
        transform.position=new Vector3(_position.x, _position.y, _position.z) ;
        Debug.Log("Karakter Pos"+transform.position);
        Debug.Log("id"+id);

        Vector3 _inputDirection = Vector3.zero;

        _inputDirection.x = _position.x;
        _inputDirection.y= _position.y;
        _inputDirection.z = _position.z;


        Move(_inputDirection);

    

    }
}
