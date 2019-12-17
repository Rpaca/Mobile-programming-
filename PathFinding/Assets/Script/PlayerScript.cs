using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    GridManager gm = null;
    ScoreManager sm = null;
    Coroutine move_coroutine = null;

	void Start ()
    {
        sm = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        gm = Camera.main.GetComponent<GridManager>() as GridManager;
        gm.BuildWorld(40, 40);
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(1) && sm.GetBlocks() > 0) // 우클릭
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.tag);
                if (hit.transform.tag == "Plane")
                {
                    gm.CreatWall(hit.point);
                    sm.CountBlocks();
                }

            }
        }
    }    
}
