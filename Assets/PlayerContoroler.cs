using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerContoroler : MonoBehaviour {
    [SerializeField]
    private float speed = 5f;
    private PlayerMotor pm;
    float lookSensitivity = 10f;
    public void Start()
    {
        pm = GetComponent<PlayerMotor>();
    }
    public void Update()
    {
        float xmov = Input.GetAxisRaw("Horizontal");
        float zmov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * xmov;
        Vector3 _moveVertical = transform.forward * zmov;
        //calcuklate Velocity
        Vector3 velocity = (_moveHorizontal + _moveVertical).normalized * speed;
        pm.Move(velocity);
        //calculate Rotation
        float _yRotation = Input.GetAxisRaw("Mouse X");
        float _xRotation = Input.GetAxisRaw("Mouse Y");
            Vector3 rotation = new Vector3(0, _yRotation, 0) * lookSensitivity;
           float Camrotation = _xRotation * lookSensitivity;
        pm.Rotate(rotation, Camrotation);
    
    }

}
