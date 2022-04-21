using UnityEngine;

using System.Collections;



public class ShootRay : MonoBehaviour
{



	public float rayDistance = 100f;
	public int ballcount = 0;

	void Start()
    {

    }



	// Update is called once per frame

	void Update()
	{

		if (Input.GetMouseButton(0))
		{// 0은 왼쪽버튼, 스마트폰에서 터치.

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //카메라에서 레이를 쏜다.

			RaycastHit hit;



			if (Physics.Raycast(ray, out hit, rayDistance))

			{

				if (hit.transform.tag == "Item")         ///   
				{
					Destroy(hit.transform.gameObject);
					ballcount = ballcount + 1;
					Debug.Log(ballcount);
				}

			}

		}

	}

}


