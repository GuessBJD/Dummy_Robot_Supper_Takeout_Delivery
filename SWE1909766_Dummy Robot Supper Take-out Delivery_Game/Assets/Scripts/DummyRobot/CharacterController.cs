using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private float smooth = 10.0f;

    private float tiltAroundY = 0f;
    private float tiltAroundZ = -90f;

    public Vector2 currentMovement { get; set; }
    [SerializeField] private Rigidbody2D vehicleRigidBody;
    [SerializeField] private GameObject pointLight;

    void Awake()
    {

    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Quaternion target;

        vehicleRigidBody.velocity = currentMovement * speed;

        target = Quaternion.Euler(0, tiltAroundY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        target = Quaternion.Euler(0, 0, tiltAroundZ);
        pointLight.transform.rotation = Quaternion.Slerp(pointLight.transform.rotation, target, Time.deltaTime * smooth);
    }

    public void SetMovement(Vector2 newPosition)
    {
        currentMovement = newPosition;
    }

    public void SetAngle(float newTiltAroundY, float newTiltAroundZ)
    {
        tiltAroundY = newTiltAroundY;
        tiltAroundZ = newTiltAroundZ;
    }

    public void Flip(bool right)
    {
        if(right == true)
        {
            vehicleRigidBody.transform.localScale = new Vector3(1f, 1f, 1f);        
        }
        else
        {
            vehicleRigidBody.transform.localScale = new Vector3(-1f, 1f, 1f);          
        }

        tiltAroundY = -tiltAroundY;
        vehicleRigidBody.transform.localRotation = Quaternion.Euler(0, tiltAroundY, 0);

        tiltAroundZ = -tiltAroundZ;
        pointLight.transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);
    }
    
    public void KnockBack(Vector2 pos)
    {
        if (vehicleRigidBody.position.y < pos.y + 0.63)
        {
            transform.position = transform.position + new Vector3(0f, -0.1f, 0f);
        }
        else
        {
            transform.position = transform.position + new Vector3(0f, +0.1f, 0f);
        }
    }

}
