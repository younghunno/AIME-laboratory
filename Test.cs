using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform bullet;
    
    public Transform startPoint;
    public Transform endPoint;
    public float g;
    public Transform heightGo;
    public Throw_ball simul;

    void Start()
    {
        
    }

    private void OnGUI()
    {  //OnGUI 화면 크기 받아서 스크린 내에 카메라 뷰에서 사용가능한 버튼을 생성시켜줍니다.
        if (GUILayout.Button("발사", GUILayout.Width(500), GUILayout.Height(200)))
        {
            var clone = Instantiate(bullet);

            this.simul.Shoot(clone, startPoint.position, endPoint.position, g, heightGo.position.y, OnCompleteThrowSimulation);
        }
    }

    private void OnCompleteThrowSimulation()
    {
        Debug.Log("도착");
    }

    void Update()
    {
        
    }
}
