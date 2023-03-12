using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator slave;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rb = slave.gameObject.GetComponent<Rigidbody>();
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            slave.SetBool("walking", true);
        }
        else
        {
            slave.SetBool("walking", false);
        }
    }
}
