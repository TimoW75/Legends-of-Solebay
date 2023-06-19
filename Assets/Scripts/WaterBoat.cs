using Ditzelgames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoat : MonoBehaviour
{
    //visible Properties
    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    //used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    protected ParticleSystem ParticleSystem;
    
    //internal Properties
    protected Vector3 CamVel;

    [SerializeField] private bl_Joystick _joystick;

    public void Awake()
    {
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }

    public void FixedUpdate()
    {


        var steer = Mathf.RoundToInt(-_joystick.Horizontal);
        print(steer);

        // forward/backward power (invert the vertical input)
        var throttle = Mathf.Clamp01(_joystick.Vertical);
        print(throttle);

        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);


        if(throttle > 0)
        {
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, transform.forward * MaxSpeed * throttle, Power);
        }

        if (throttle < 0)
        {
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, transform.forward * MaxSpeed * throttle, Power);
        }

        if (ParticleSystem != null)
        {
            if (Mathf.RoundToInt(-_joystick.Horizontal) != 0)
                ParticleSystem.Play();
            else
                ParticleSystem.Pause();
        }

        //moving forward
        var movingForward = Vector3.Cross(transform.forward, Rigidbody.velocity).y < 0;

        //move in direction
        Rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(Rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * Rigidbody.velocity;
    }

}