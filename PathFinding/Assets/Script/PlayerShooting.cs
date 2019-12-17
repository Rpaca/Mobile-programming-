using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Transform fireTransform;
    [SerializeField]
    private AudioSource gunSound;
    private int damage = 20;
    private float coolTime = 0.2f;
    private float fireDistance = 10.0f;


    float timer;                                    
    Ray shootRay;                                  
    RaycastHit hitPoint;                           

    public LineRenderer bulletLineRenderer;                       
    float effectsDisplayTime = 0.2f;               

    void Start()
    {
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= coolTime)
            Shoot();

        if (timer >= coolTime * effectsDisplayTime)
            bulletLineRenderer.enabled = false;
    }



    void Shoot()
    {
        timer = 0.0f;
        gunSound.Play();
     
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        bulletLineRenderer.enabled = true;
        bulletLineRenderer.SetPosition(0, fireTransform.position);

        if (Physics.Raycast(shootRay, out hitPoint, fireDistance))
        {
            Life Life = hitPoint.collider.GetComponent<Life>();
            if (Life != null)
            {
                Life.getDamage(damage);
            }

            bulletLineRenderer.SetPosition(1, hitPoint.point);
        }

        else
        {
           
            bulletLineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * fireDistance);
        }
    }
}
