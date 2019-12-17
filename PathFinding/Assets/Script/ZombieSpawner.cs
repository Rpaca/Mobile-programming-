using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Zombie;
    private int maxZombieN = 6;
    private int nowZombieN = 0;
    private float timer;
    private float spawnCoolTime = 1.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (nowZombieN < maxZombieN && timer >= spawnCoolTime)
        {
            Instantiate(Zombie, this.transform.position, this.transform.rotation);
            nowZombieN++;
            timer = 0;
        }
    }

    public void CountDeadZombies()
    {
        nowZombieN--;
    }
}
