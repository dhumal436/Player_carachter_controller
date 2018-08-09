using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
    public Vector3 velocity = Vector3.zero;
    Vector3 _rot = Vector3.zero;
    float _camrot = 0f;
    float currentRotation = 0f;
    float camLimit = 85f;
    private Rigidbody rb;
    [SerializeField]
    private Camera cam;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Debug.Log(Mathf.Clamp(10, 1, 3));
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        PerformMovement();
        PerformRotation();
	}
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
        
    }
    public void Rotate(Vector3 rotation, float camRot) {
        _rot=rotation;
        _camrot = camRot;

    } 


    private void PerformMovement()
    {
        if(velocity!=null)
        {
            //MOveplayer
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        if ( cam!=null)
        {
            
            currentRotation -= _camrot;
            currentRotation = Mathf.Clamp(currentRotation,-camLimit,camLimit);
            cam.transform.localEulerAngles=new Vector3(currentRotation, 0f, 0f);//limited Rotation 
        }

        //Rotate on x axis
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_rot));
    }

}
