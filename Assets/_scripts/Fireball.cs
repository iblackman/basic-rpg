using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage = 1;
    [Range(25,80)]
    public float speed;
    [Range(5,30)]
    public float maxDistance;

    Vector3 spawnPosition;

    private void Start()
    {
        Range = maxDistance;
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
