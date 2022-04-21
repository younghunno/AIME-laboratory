using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    private bool state;
    public GameObject Target;
    public GameObject ShootRay;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Main Camera").GetComponent<ShootRay>().ballcount == 1)
        {



            Target.SetActive(true);



         }
        else
        {
            Target.SetActive(false);
        }

    }
    
}
