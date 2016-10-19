using System;
using UnityEngine;
using System.Collections;
using getReal3D;

public class FreeCam : MonoBehaviour {

    public Vector3 ResetPosition;
    public Vector3 ResetRotation;
    public float MovementSpeed = 10.0f;
    public float RotationSpeed = 0.5f;
    public float BonusSpeed = 10.0f;

    public string SpeedButton = "Speed";
    public string ResetButton = "Reset";


    private const string ForwardAxis = "Forward";
    private const string StrafeAxis = "Strafe";
    private const string YawAxis = "Yaw";
    private const string PitchAxis = "Pitch";

    private TextMesh m_textMesh;
    private Transform m_transform;

    

    // Use this for initialization
    void Start()
    {
        m_transform = transform;
        // m_textMesh = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

        if (getReal3D.Input.GetButtonDown(ResetButton))
        {
            m_transform.rotation = Quaternion.Euler(ResetRotation);
            m_transform.position = ResetPosition;
            return;
        }

        /* // Write text on screen about inputs... for testing
         * m_textMesh.text = "Forward : " + Mathf.Round(getReal3D.Input.GetAxis(forwardAxis)) + "\n";
         * m_textMesh.text += "Strafe : " + Mathf.Round(getReal3D.Input.GetAxis(strafeAxis)) + "\n";
         * m_textMesh.text += "Pitch : " + Mathf.Round(getReal3D.Input.GetAxis(pitchAxis)) + "\n";
         * m_textMesh.text += "Yaw : " + Mathf.Round(getReal3D.Input.GetAxis(yawAxis));
         */

        // Get the forward and strafe values
        Vector3 input = GetMovementInput();

        // Increase vector force by movement speed multiplier so movement isn't crazy slow.
        input = input*MovementSpeed;

        // Supposed to make you move faster when you press down on left joystick.. doesn't seem to work.
        if (getReal3D.Input.GetButton(SpeedButton))
        {
            input = input * BonusSpeed;
        }

        // Multiply vector force by the time between the last frame and this frame.
        input = input*Time.deltaTime;

        // Transform based off input
        m_transform.Translate(input);

        // Rotate the camera based on the input, with the world as the reference point for rotation
        m_transform.Rotate(GetRotationInput(), Space.World);


    }


    private Vector3 GetMovementInput()
    {
        // Make new vector and set input values in right place. 
        return new Vector3(getReal3D.Input.GetAxis(StrafeAxis), 0, getReal3D.Input.GetAxis(ForwardAxis));
        
        // Vector[x] is left and right movement
        // Vector[y] is vertical movement
        // Vector[z] is forward and backward movement
    }

    private Vector3 GetRotationInput()
    {
        // Make new vector and set input values
        // Input values are multiplied by the rotation speed here to prevent unecessary memory usage by creating another vector to multiply above.
        return new Vector3((getReal3D.Input.GetAxis(PitchAxis) * -1) * RotationSpeed,
            getReal3D.Input.GetAxis(YawAxis)*RotationSpeed, 0);
    }
}
