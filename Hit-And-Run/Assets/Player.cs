using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    
    float hAxis;
    float vAxis;

    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed", 1.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        anim.SetFloat("Speed", new Vector3(hAxis, 0, vAxis).magnitude);

        // Position
        transform.position += moveVec * anim.speed * Time.deltaTime;

        // Rotation
        transform.LookAt(transform.position + moveVec);
    }
}
