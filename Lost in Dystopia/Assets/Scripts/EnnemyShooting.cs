using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject target;
    public GameObject self;
    private Vector3 aimDirection;
    private float timer;
    private Transform aimTransform;

    // Start is called before the first frame update
    void Start()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        
        aimDirection = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Vector3 aimLocalScale = Vector3.one;
        Vector3 playerLocalScale = new Vector3(3,3,3);
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.x = +0.5f;
            aimLocalScale.y = -0.5f;
            playerLocalScale.x = +3f;
        }
        else
        {
            aimLocalScale.x = -0.5f;
            aimLocalScale.y = +0.5f;
            playerLocalScale.x = -3f;
        }
        aimTransform.localScale = aimLocalScale;
        self.transform.localScale = playerLocalScale;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(aimTransform.eulerAngles);
        timer += Time.deltaTime;
        if (timer > 2)
        {
            if (timer >2.15)
            {
                timer = 0;
                
            }
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
