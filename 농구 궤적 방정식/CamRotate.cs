using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    float mx;
    float my;

    public Animator cubeAnim;

    void Start()
    {

    }

    void Update()
    {
        // 마우스의 입력을 받아오고 싶다.
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        // 마우스 입력 값을 저장 해두고 싶다. 
        mx += mouseX;
        my += mouseY;

        // 마우스 위 아래 회전에 제한을 두고 싶다. 
        my = Mathf.Clamp(my, -70, 70);

        // 카메라의 회전 값을 저장한 값으로 넣어 주고 싶다.  
        transform.rotation = Quaternion.Euler(new Vector3(-my, mx, 0));
    }
}
