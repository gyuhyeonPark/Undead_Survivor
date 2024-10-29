using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    float hAxis;
    float vAxis;

    Vector3 moveVec;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving", false);
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

        if (moveVec.magnitude >= 1.0f)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

        // Position
        transform.position += moveVec * speed * Time.deltaTime;

        // Rotation
        transform.LookAt(transform.position + moveVec);

        Debug.Log(moveVec.magnitude);
        Debug.Log(anim.GetBool("IsMoving"));
    }

    private void FixedUpdate()
    {
        
    }
}
