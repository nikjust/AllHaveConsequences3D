using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public class Spawnable
{
    
    public Vector3 position;
    public GameObject _object;
    
    
    
    public Spawnable(Vector3 pos, GameObject obj)
    {
        this.position = pos;
        this._object = obj;
    }

}

public class RandomiserEvents : MonoBehaviour
{
    public Vector2 topRight;
    public Vector2 downLeft;
    public GameObject[] eventObjects;

    public float distance;

    public Vector3 center;

    public Spawnable[] objList;
    // Start is called before the first frame update
    void Start()
    {
        var list = FastPoissonDiskSampling.Sampling(downLeft, topRight, distance);

        foreach (var point in list)
        {
            Vector3 TriPoint = new Vector3(point.x, 0, point.y);

            int index = (int) Math.Floor((float) Random.value * eventObjects.Length);

            Instantiate(eventObjects[index], TriPoint + eventObjects[index].transform.position, eventObjects[index].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
