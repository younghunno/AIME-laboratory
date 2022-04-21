using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Camera cam;
    public CharacterController cc;

    public float speed = 2f;
    public float jumpPower = 7f;
    public float gravity = -9.8f;
    float jumpSpeed;
    public Animator playerani;
    public Animator jumpani;
    bool isWalk;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 tempForward = cam.transform.forward;
        tempForward.y = 0;
        transform.forward = tempForward;
        Vector3 dir = transform.forward * v + transform.right * h;
        dir = dir.normalized;

        if (cc.isGrounded)
        {
            jumpSpeed = -0.1f;
        }
        else
        {
            jumpSpeed += gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            jumpSpeed = jumpPower;
        }
        dir.y = jumpSpeed;
        cc.Move(dir * speed * Time.deltaTime);

        if (h != 0 || v != 0)
        {
            if (!isWalk) //키를 누른다면 
            {
                isWalk = true; //걸어준다.
                
                //jumpani.SetBool("BJump", true);
               
                playerani.SetBool("BWalk", true); // bool형
            }
            
        }
        else
        {
            if (isWalk) //키를 떼면 
            {
                isWalk = false; //걷고있지 않은 상태 
                                
                playerani.SetBool("BWalk", false);
            }
        }

    }
}
