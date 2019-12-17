using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState
{
    Wandering,
    Tracing,
    Attacking
}

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private ZombieState state = ZombieState.Wandering;

    GridManager gm = null;
    GameObject player;
    Coroutine move_coroutine = null;
    private int damage = 10;
    [SerializeField]
    Vector3 targetPosition;
    const float visibleRange = 15.0f;


    void Start()
    {
        gm = Camera.main.GetComponent<GridManager>() as GridManager;
        player = GameObject.Find("Player");
        state = ZombieState.Wandering;
        targetPosition = transform.position;
    }

    float calcDistanceToPlayer()
    {
        if (player == null) return Mathf.Infinity;
        float dist = Vector3.Distance(transform.position, player.transform.position);
        return dist;
    }

    void Update()
    {
        switch (state)
        {
            case ZombieState.Wandering:
                if (Vector3.Distance(targetPosition, transform.position) < 5.0f && move_coroutine == null)
                {
                    targetPosition = transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f));
                }
                if(move_coroutine != null) StopCoroutine(move_coroutine); // 이동 중이면 이동을 멈춤
                move_coroutine = StartCoroutine(gm.Move(gameObject,targetPosition)); // 이동 시작;
                break;

            case ZombieState.Tracing:
                if (move_coroutine != null) StopCoroutine(move_coroutine); // 이동 중이면 이동을 멈춤
                move_coroutine = StartCoroutine(gm.Move(gameObject, player.transform.position)); // 이동 시작
                break;

            case ZombieState.Attacking:
                Sleep();
                break;

        }

        float dist = calcDistanceToPlayer();
        if (dist < visibleRange)
        {
            state = ZombieState.Tracing;
        }
        else
        {
            state = ZombieState.Wandering;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            state = ZombieState.Attacking;
            print("hit");
            var playerLife = collision.gameObject.GetComponent<Life>();
            playerLife.getDamage(damage);
        }
    }

    IEnumerable Sleep()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
