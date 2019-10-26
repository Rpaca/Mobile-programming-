using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAim : MonoBehaviour {

    [SerializeField]
    private float speed = 0.1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float x = Input.mousePosition.x - Screen.width / 2;
        //float y = Input.mousePosition.y - Screen.height / 2;
        //print("x:"+ x +",y:"+y + ",mouspos:" + Input.mousePosition + ",w:" + Screen.width + ",h:" + Screen.height); //public이 아닌데 소문자를 사용했음
        //float x = Input.GetAxis("Mouse X"); // 마우스 증분을 계+
        //float y = Input.GetAxis("Mouse Y"); // 마우스 증분을 계+
        float x = 0.0f;
        float z = 0.0f;


        //getkey는 누르고 있는 동안 작동되기에 여러번 작동됨 -> getkeydown or getkeyup 사용
        if (Input.GetKeyDown(KeyCode.W))
        {
            z -= 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            z += 1;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("A");
            x += 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            x -= 1;
        }

        //transform.eulerAngles = new Vector3(y * speed * -1, x * speed, 0);
        //transform.eulerAngles += new Vector3(y * -speed, x * speed, 0);
        transform.position += new Vector3(x, 0, z);


    }
}
