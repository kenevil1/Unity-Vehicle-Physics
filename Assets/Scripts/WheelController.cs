using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

    public WheelAlignment[] steerableWheels;

    //Steering variables
    public float wheelRotateSpeed;
    public float wheelSteeringAngle;

    //Motor variables
    public float wheelAcceleration;
    public float wheelMaxSpeed;

    // Update is called once per frame
    void Update ()
    {
        wheelControl();
	}

    //Applies steering and motor torque
    void wheelControl()
    {
        for (int i = 0; i < steerableWheels.Length; i++)
        {
            //Sets default steering angle
            steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, 0, Time.deltaTime * wheelRotateSpeed);
            //Sets default motor speed
            steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, 0, Time.deltaTime * wheelAcceleration);

            //Steering controls
            if (Input.GetKey(KeyCode.A))
            {
                steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, -wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                steerableWheels[i].steeringAngle = Mathf.LerpAngle(steerableWheels[i].steeringAngle, wheelSteeringAngle, Time.deltaTime * wheelRotateSpeed);
            }

            //Motor controls
            if (Input.GetKey(KeyCode.W))
            {
                steerableWheels[i].wheelCol.motorTorque = -Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration);
            }

            if (Input.GetKey(KeyCode.S))
            {
                steerableWheels[i].wheelCol.motorTorque = Mathf.Lerp(steerableWheels[i].wheelCol.motorTorque, wheelMaxSpeed, Time.deltaTime * wheelAcceleration);
            }
        }
    }

}
