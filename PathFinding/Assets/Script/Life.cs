using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private int lifePoint = 50;


    public void getDamage(int damage)
    {
        lifePoint -= damage;
        CheckLifePoint();
    }

    private void CheckLifePoint()
    {
        if (lifePoint <= 0)
        {
            var spawner = GameObject.Find("ZombieSpawner").GetComponent<ZombieSpawner>();
            var gm = GameObject.Find("GameManager").GetComponent<ScoreManager>();
            if (this.gameObject.name != "Player")
            {
                gm.AddScore();
                spawner.CountDeadZombies();
            }
            Destroy(this.gameObject);
        }
    }
}
