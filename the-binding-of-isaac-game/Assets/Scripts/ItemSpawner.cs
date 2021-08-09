﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public bool ready = false;
    [System.Serializable]
    
    public struct Spawnable
    {
        public GameObject gameObject;
        public float weight;
    };
    public List<Spawnable> items = new List<Spawnable>();
    float totalWeight;
    private void Awake()
    {
        totalWeight = 0;
        foreach(var spawnable in items)
        {
            totalWeight += spawnable.weight;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        float pick = Random.value * totalWeight;
        int chosenIndex = 0;
        float cumulativeWeight = items[0].weight;
        while(pick>cumulativeWeight && chosenIndex < items.Count - 1)
        {
            chosenIndex++;
            cumulativeWeight += items[chosenIndex].weight;
        }
        // GameObject i = Instantiate(items[chosenIndex].gameObject, transform.position,
        //Quaternion.identity) as GameObject;
        Instantiate(items[chosenIndex].gameObject, transform.position,
            Quaternion.identity).transform.parent = transform.parent;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Room")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        checkCollider(collision);

    }
    public void checkCollider(Collision2D collision)
    {
        if (collision!= null)
        {
           ready = true ;
        }
        else
            ready=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
