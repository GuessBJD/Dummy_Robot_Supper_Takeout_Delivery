using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterContainer : MonoBehaviour
{
    //protected float horizontalInput;
    //protected float verticalInput;

    [SerializeField]protected BagManager bagManager;

    protected CharacterController controller;
    protected CharacterMovement movement;
    protected Animator animator;
    protected GameObject food;

    [SerializeField] protected AudioSource walkSoundEffect;
    [SerializeField] protected AudioSource systemSoundEffect;
    [SerializeField] protected AudioSource collideSoundEffect;
    [SerializeField] protected Text identifierLog;

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleInput();
        InternalInput();
    }

    protected virtual void HandleAbility()
    {
        //InternalInput();
        //HandleInput();
    }

    protected virtual void HandleInput()
    {
 
    }

    protected virtual void InternalInput()
    {

    }

}
