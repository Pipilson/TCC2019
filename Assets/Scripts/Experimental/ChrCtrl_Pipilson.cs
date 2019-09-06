﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChrCtrl_Pipilson : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float highSpeed = 9.0f;
    public float gravity = 20.0f;

 

    #region Pulo
    [Header("Pulo")]
    public float jumpTime = 1.0f;
    float jumpTimeCounter;
    public float jumpSpeed = 10.0f;
    public float jumpHighSpeed = 15f;
    bool isJumping;
    #endregion

    public int pulosDados; //Pipilson
    public int puloLimite = 1; //Pipilson

    #region Aceleracao
    [Header("Aceleracao")]
    float timer = 0.0f;
    bool fast;
    #endregion

    public Vector3 moveDirection = Vector3.zero; //Deixei public -Pipilson

    public GameObject ashModel;
    Animator anim;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        anim = ashModel.GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        #region CharCtrl
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = transform.right * horizontal;
            pulosDados = 0;
            gravity = 20f;

            #region Aceleracao
            if (Input.GetButton("Horizontal") && timer >= 1.5f)
            {
                fast = true;
            }
            else if (Input.GetButton("Horizontal"))
            {
                timer += Time.deltaTime;
            }
            else
            {
                fast = false;
                timer = 0.0f;
            }
            #endregion

        }
        else
        {
            moveDirection = new Vector3(transform.right.x * Input.GetAxis("Horizontal"), moveDirection.y, 0);
        }

        // Se ainda não for atingido o limite de pulos permitir pular denovo
        if (Input.GetButtonDown("Jump") && pulosDados < puloLimite) //Alterei esse if -Pipilson
        {
            moveDirection.y = jumpHighSpeed;
            pulosDados++;
        }

        //Comentei toda essa region -Pipilson
        #region Pulo Adaptável
        //if (Input.GetButton("Jump"))
        //{
        //    if (isJumping && pulos < 2)
        //    {
        //        moveDirection.y = jumpHighSpeed;
        //        pulos++;
        //        jumpTimeCounter -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        isJumping = false;
        //    }
        //}

        //if (Input.GetButtonUp("Jump"))
        //{
        //    isJumping = false;
        //}
        #endregion

        #region Aceleracao
        if (fast)
        {
            moveDirection.x *= highSpeed;
        }
        else
        {
            moveDirection.x *= speed;
        }
        #endregion

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        ashModel.transform.rotation = Quaternion.Euler(0, 180 - 90 * horizontal, 0);
        if (anim != null)
        {
            anim.SetFloat("Vel", Mathf.Abs(horizontal));
        }
        #endregion
    }
}