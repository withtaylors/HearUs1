using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variable
    public float runSpeed;

    Rigidbody myRB;
    Animator myAnim;

    bool facingRight;
    //bool facingFront;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    //버튼을 눌렀는지 감지하기위함
    void FixedUpdate()
    {
        float hmove = Input.GetAxis("Horizontal");
        //float vmove = Input.GetAxis("Vertical");

        myAnim.SetFloat("speed", Mathf.Abs(hmove));
        //myAnim.SetFloat("speed", Mathf.Abs(vmove));

        myRB.velocity = new Vector3(0, myRB.velocity.y, -hmove * runSpeed);
        //myRB.velocity = new Vector3(vmove * runSpeed, myRB.velocity.y, -hmove * runSpeed);

        if (hmove > 0 && facingRight) Flip();
        else if (hmove < 0 && !facingRight) Flip();

/*        if (vmove > 0 && facingFront) Flip2();
        else if (vmove < 0 && !facingFront) Flip2();*/
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;

        theScale.z *= -1;
        transform.localScale = theScale;
    }

/*    void Flip2()
    {
        facingFront = !facingFront;
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    }*/
}
