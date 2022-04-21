using UnityEngine;
using System.Collections;

public class Throw_ball : MonoBehaviour
{
    private Transform bullet;   // 포물체
    private float tx;  // x 축 속도
    private float ty;  //y축 속도
    private float tz; //z 축 속도  
    private float v; 
    private float g = 9.8f;  //중력가속도
    private float elapsed_time;  //흐르는 시간
    private float max_height;  //최대 높이
    //private float t;   
    private Vector3 start_pos;  //출발지점 
    private Vector3 end_pos;   // 목적지점
    private float dat;  //도착점 도달 시간 (= EndTime)
    

    public void Shoot(Transform bullet, Vector3 startPos, Vector3 endPos, float g, float max_height, System.Action onComplete)
    {

        start_pos = startPos; // 지역변수 Vector3를 start_pos에 저장
        end_pos = endPos; //지역변수 Vector3를 end_pos에 저장 

        this.g = g; 
        this.max_height = max_height; //높이
        this.bullet = bullet;
        this.bullet.position = start_pos;
        //var를 사용하여 단서를 암시적으로 제시하여 형식화된 지역변수(메소드 내)로 사용
        var dh = endPos.y - startPos.y;   //dh = 마지막지점(y축) - 시작지점(y축)
        var mh = max_height - startPos.y; // mh = 높이 - 시작지점(y축)
        ty = Mathf.Sqrt(2 * this.g * mh); // ty = 루트(2*g*mh)

        float a = this.g;   //a = gravity
        float b = -2 * ty;  // b = -2 * y축으로의 속도
        float c = 2 * dh;  // c = 2 (마지막지점(y축) - 시작지점(y축))

        dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);  // -(-2ty)+ 루트[(b^2 -8g[endPos - startPos]))]/2g

        tx = -(startPos.x - endPos.x) / dat; //  x 축 속도 : -(시작점(x축) - 마지막 지점(x축))/dat
        tz = -(startPos.z - endPos.z) / dat; // z 축 속도 : -(시작점(z축) - 마지막 지점(z축))/dat

        this.elapsed_time = 0; //흐르는 시간을 0으로 초기화 

        StartCoroutine(this.ShootImpl(onComplete));
    }

    IEnumerator ShootImpl(System.Action onComplete)
    {
        while (true)  //Schedule 부분 
        {
            this.elapsed_time += Time.deltaTime;
            var tx = start_pos.x + this.tx * elapsed_time;
            var ty = start_pos.y + this.ty * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
            var tz = start_pos.z + this.tz * elapsed_time;
            var tpos = new Vector3(tx, ty, tz);

            bullet.transform.LookAt(tpos);
            bullet.transform.position = tpos;



            if (this.elapsed_time >= this.dat)

                break;
            yield return null;

        }
        onComplete();
    }

}
