using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    public float speed = 50f;
    public float maxDistance = 30f;

    Vector3 spawnPosition;

    private void Start()
    {
        Range = maxDistance;
        Damage = 4;
        spawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * speed);
    }

    private void Update()
    {
        if(Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Delete();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        Delete();
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
