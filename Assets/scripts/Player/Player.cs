using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>playerの挙動を行う</summary>
public class Player : MonoBehaviour
{
    new Rigidbody rigidbody;
    [SerializeField] public float playerSpeed = 5f;
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

        rigidbody.velocity = new Vector3(h, 0, v);
    }
}
