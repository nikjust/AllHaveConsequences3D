using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public Inventory player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yup");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy");
            int damage = player.mainHand.damage;
            Vector3 playerPos = player.transform.position;
            Vector3 enemyPos = other.transform.position;
            other.gameObject.GetComponent<Enemy>().DealDamage(damage);
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            rb.velocity = new Vector3((enemyPos.x - playerPos.x)*(damage/2), damage, (enemyPos.z - playerPos.z)*(damage/2) );
        }
    }
}
