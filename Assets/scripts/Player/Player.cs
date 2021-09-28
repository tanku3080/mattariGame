using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>playerの挙動を行う</summary>
public class Player : MonoBehaviour
{
    new Rigidbody rigidbody;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float rotationSpeed = 10f;
    /// <summary>角度制限の値</summary>
    [SerializeField] float limitRotY = 70;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //一人称ゲームなので等速移動を行うようにしている
        var v = Input.GetAxis("Vertical") * playerSpeed;
        var h = Input.GetAxis("Horizontal") * playerSpeed;
        var rotX = Input.GetAxis("Mouse X") * rotationSpeed;
        var rotY = Input.GetAxis("Mouse Y") * rotationSpeed;

        rigidbody.velocity = new Vector3(h, 0, v);
        transform.Rotate(0,rotX,0);
        if (rotY >= -limitRotY && rotY <= limitRotY)
        {
            transform.localEulerAngles = new Vector3(rotY,0,0);
        }
    }
}
