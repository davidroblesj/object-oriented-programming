using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorDTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject player = GameObject.Find("Player");
            Vector3 mov = new Vector3(0, -150, 0);
            player.transform.position = player.GetComponent<Transform>().position + mov;
        }
        
    }
}
