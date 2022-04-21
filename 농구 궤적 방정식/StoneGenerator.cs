using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Basketball_3DS; //GameObject 선언
    public GameObject ShootRay;
    public Transform spawnerPosition;
    public GameObject target;
    //public Rigidbody target;

    // Update is called once per frame


    void Start()
    {
        //target = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (GameObject.Find("Main Camera").GetComponent<ShootRay>().ballcount == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {   //stone을 생성하고 발사!
                //transform.position = new Vector3(10f, 10f, -10f);
                //Instantiate(Basketball_3DS, spawnerPosition.position);

                Instantiate(target, spawnerPosition.position, spawnerPosition.rotation);

                
                //target.AddForce(transform.forward * 10);

                //Basketball_3DS.GetComponent<StoneController>().Shoot(new Vector3(0, 2000, 20));
                GameObject.Find("Main Camera").GetComponent<ShootRay>().ballcount -= 1;
               // Debug.Log(GameObject.Find("Main Camera").GetComponent<ShootRay>().ballcount);
            }
        }
    }
}