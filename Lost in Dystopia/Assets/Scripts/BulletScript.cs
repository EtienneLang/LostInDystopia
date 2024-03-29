using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Collidable
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public GameObject blood;
    // Start is called before the first frame update
    protected override void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }




    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (coll.tag == "Fighter")
        {
            Debug.Log(coll.tag);
            Damage dmg = new Damage();
            dmg.nbHitPoints = Random.Range(8, 15);
            coll.SendMessage("ReceiveDamage",dmg);
            Destroy(gameObject);
            Debug.Log(gameObject.name);
            Instantiate(blood, transform.position, Quaternion.identity);
            Debug.Log(transform.position);
        }
    }
}
