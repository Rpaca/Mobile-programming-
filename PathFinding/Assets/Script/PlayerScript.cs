using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    GridManager gm = null;
    Coroutine move_coroutine = null;

	void Start ()
    {
        gm = Camera.main.GetComponent<GridManager>() as GridManager;
        gm.BuildWorld(50, 50);
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라로부터 스크린의 점으로 레이 반환
            RaycastHit hit; // 레이케스트 구조체
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Wall" && hit.normal == Vector3.up)
                { // 이미 벽돌이 있는 경우
                    var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    wall.tag = "Wall";
                    wall.transform.position = hit.transform.position + Vector3.up; // 벽 생성
                    return;
                }
                if (move_coroutine != null) StopCoroutine(move_coroutine); // 이동 중이면 이동을 멈춤
                move_coroutine = StartCoroutine(gm.Move(gameObject, hit.point)); // 이동 시작                
            }
        }
        else if (Input.GetMouseButtonDown(1)) // 우클릭
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.tag);
                if (hit.transform.tag == "Plane")// 벽돌이 없는 경우
                {
                    var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    wall.tag = "Wall";
                    wall.transform.position = gm.pos2center(hit.point);
                    gm.SetAsWall(wall.transform.position); // 벽 생성
                }
            }
        }
    }    
}
