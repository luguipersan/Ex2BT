using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float maxDistance;

    private GameObject enemyTrigger;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (hit.gameObject.tag == "Enemy")
        {
            enemyTrigger = hit.gameObject;
            enemyTrigger.GetComponent<EnemyDeath>().enemyHealth -= damage;
            Destroy(this.gameObject);
            Debug.Log("hit");
        }
    }
}

