using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    GridManager gm = null;
    GameObject player;
    Coroutine move_coroutine = null;

    void Start()
    {
        gm = Camera.main.GetComponent<GridManager>() as GridManager;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (move_coroutine != null) StopCoroutine(move_coroutine); // 이동 중이면 이동을 멈춤
        move_coroutine = StartCoroutine(gm.Move(gameObject, player.transform.position)); // 이동 시작                
    }
}
