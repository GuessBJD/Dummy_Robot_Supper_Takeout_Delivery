using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterContainer
{
    //private readonly int movingParamater = Animator.StringToHash("Moving");

    private const float TILT_ANGLE = 35f;
    private const float TILT_ANGLE_LIGHT = 25f;
    private float tiltAngleYDef = 0f;
    private float tiltAngleZDef = -90f;
    private float tiltAngleY;
    private float tiltAngleZ;

    public Vector2 moveDirection;

    private bool started = false;
    private bool firstToggle = false;
    private int toggleCount = 1;
    private bool clockwise = true;
    private bool right = true;
    

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void HandleInput()
    {
        base.HandleInput();

        if (started == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                active();
                started = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (food != null)
                {
                    systemSoundEffect.Play();
                    bagManager.grab(food.GetComponent<FoodRegister>().getItemEntry());
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                systemSoundEffect.Play();
                bagManager.dropAll();
            }
        }
    }

    protected override void InternalInput()
    {
        base.InternalInput();

        if(started == true)
        {
            if(firstToggle == false)
            {
                firstToggle = true;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (clockwise == true)
                    {
                        toggleCount += 1;
                        if (toggleCount >= 2)
                        {
                            clockwise = false;
                        }
                    }
                    else
                    {
                        toggleCount -= 1;
                        if (toggleCount <= 0)
                        {
                            clockwise = true;
                        }
                    }

                    switch (toggleCount)
                    {
                        case 0:
                            moveDirection.y = -1.25f;
                            tiltAngleY = tiltAngleYDef - TILT_ANGLE;
                            if (right == true)
                                tiltAngleZ = tiltAngleZDef - TILT_ANGLE_LIGHT;
                            else
                                tiltAngleZ = tiltAngleZDef + TILT_ANGLE_LIGHT;
                            controller.SetAngle(tiltAngleY, tiltAngleZ);
                            break;
                        case 1:
                            moveDirection.y = 0f;
                            tiltAngleY = tiltAngleYDef;
                            tiltAngleZ = tiltAngleZDef;
                            controller.SetAngle(tiltAngleY, tiltAngleZ);
                            break;
                        case 2:
                            moveDirection.y = 1.25f;
                            tiltAngleY = tiltAngleYDef + TILT_ANGLE;
                            if (right == true)
                                tiltAngleZ = tiltAngleZDef + TILT_ANGLE_LIGHT;
                            else
                                tiltAngleZ = tiltAngleZDef - TILT_ANGLE_LIGHT;
                            controller.SetAngle(tiltAngleY, tiltAngleZ);
                            break;
                        default:
                            moveDirection.y = 0f;
                            tiltAngleY = tiltAngleYDef;
                            tiltAngleZ = tiltAngleZDef;
                            controller.SetAngle(tiltAngleY, tiltAngleZ);
                            break;
                    }

                }

                Move();
            }
            
        }
        
        //UpdateAnimations();
    }

    private void Move()
    {
        controller.SetMovement(moveDirection.normalized);
    }

    protected void active()
    {
        moveDirection = new Vector2(2f, 0f);
        Move();
        animator.SetBool("walk", true);
        walkSoundEffect.Play();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        collideSoundEffect.Play();

        if (col.gameObject.CompareTag("borderX"))
        {
            moveDirection.x = -moveDirection.x;
            Move();

            if (moveDirection.x >= 0)
            {
                right = true;
                controller.Flip(right);
            }
            else
            {
                right = false;
                controller.Flip(right);
            }

            tiltAngleYDef = -tiltAngleYDef;
            tiltAngleZDef = -tiltAngleZDef;
        }
        else if (col.gameObject.CompareTag("borderY"))
        {
            moveDirection.y = -moveDirection.y;
            Move();

            if (moveDirection.y > 0)
            {              
                toggleCount = 2;
                tiltAngleY = tiltAngleYDef + TILT_ANGLE;
                if (right == true)
                {
                    tiltAngleZ = tiltAngleZDef + TILT_ANGLE_LIGHT;
                }
                else
                {
                    tiltAngleZ = tiltAngleZDef - TILT_ANGLE_LIGHT;
                }                    
                controller.SetAngle(tiltAngleY, tiltAngleZ);
            }
            else if (moveDirection.y < 0)
            {
                toggleCount = 0;
                tiltAngleY = tiltAngleYDef - TILT_ANGLE;
                if (right == true)
                {
                    tiltAngleZ = tiltAngleZDef - TILT_ANGLE_LIGHT;
                }
                else
                {
                    tiltAngleZ = tiltAngleZDef + TILT_ANGLE_LIGHT;
                }                   
                controller.SetAngle(tiltAngleY, tiltAngleZ);
            }
            else
            {
                
            }

            ContactPoint2D contact = col.contacts[0];
            Vector2 pos = contact.point;
            controller.KnockBack(pos);
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            food = col.gameObject;
            identifierLog.text = "$[SYSTEM].Identifier " + food.GetComponent<FoodRegister>().getItemEntry().getItem();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            if (col.gameObject == food)
            {
                food = null;
                identifierLog.text = "";
            }
        }
    }

    /*private void UpdateAnimations()
    {
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            animator.SetBool(movingParamater, value: true);
        }
        else
        {
            animator.SetBool(movingParamater, value: false);
        }
    }*/
}
