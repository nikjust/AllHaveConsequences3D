using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class monsterBurst : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject enemyPrefab;
    public Vector3 spawnOffset;
    public Vector3 velocityMultiplier;
    public Vector3 velocityPreAdditor;
    public Vector3 velocityPostAdditor;
    public int count;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 VectorMultipling(Vector3 q, Vector3 w)
    {
        var e = new Vector3(q.x * w.x, q.y * w.y, q.z * w.z);
        
        Debug.Log(q);
        Debug.Log(w);
        Debug.Log(e);
        
        
        return e;
    }

    public void StartEvent()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newEnemy = enemyPrefab;

            Vector3 randomVector = new Vector3(Random.value, Random.value, Random.value);
            Vector3 velocity = VectorMultipling(randomVector + velocityPreAdditor, velocityMultiplier) + velocityPostAdditor;
            
            
            
            
            var ex = Instantiate(enemyPrefab, transform.position + spawnOffset, transform.rotation);
            var rb = ex.GetComponent<Rigidbody>();
            rb.velocity = velocity;
            ex.GetComponent<Enemy>().stun();
            
        }
        
        
    }
}
