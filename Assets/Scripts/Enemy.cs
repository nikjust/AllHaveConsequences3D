using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float health;
    public float defense;
    public float damage;
    public float attackDistance;
    public float viewDistance;
    [HideInInspector]
    private Transform _target;
    [SerializeField]
    private NavMeshAgent _navMesh;
    
    [SerializeField]
    private float cooldown;

    [TagField] public string TargetTag;
    private float lastTime = 0;
    public bool stuned = true;
    
    
    Boolean randomBoolean()
    {
        return (Random.value >= 0.5);
    }
    
    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(TargetTag).transform;
    }

    private void Update()
    {
        if (GetComponent<Rigidbody>().velocity == Vector3.zero && stuned)
        {
            stuned = false;
            _navMesh.enabled = true;
        }

        var distance = Vector3.Distance(transform.position, _target.position);
        if (distance < viewDistance && health > 0)
        {
            _navMesh.destination = _target.position;
            
            if (distance < attackDistance && randomBoolean() && Time.time - lastTime > cooldown)
            {
                
                lastTime = Time.time;
                _target.GetComponent<BattleSystem>().dealDamage(damage);
            }
        }
    }
    
    public void stun()
    {
        stuned = true;
        _navMesh.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        var position = transform.position;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(position, viewDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(position, attackDistance);
    }


    public void DealDamage(int _damage)
    {
        if (_damage > defense)
        {
            health -= _damage;
        }
    }
}
