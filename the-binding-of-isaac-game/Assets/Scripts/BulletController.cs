using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    public bool isEnemyBullet = false;
    private Vector2 lastPos;
    private Vector2 currPos;
    private Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
        if (!isEnemyBullet)
        {
            transform.localScale = new Vector2(GameController.BulletSize, GameController.BulletSize);
        }
        //transform.localScale = new Vector3(GameController.BulletSize,
            //GameController.BulletSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyBullet)
        {
            currPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position,
                playerPos, 50f * Time.deltaTime);
            if (currPos == lastPos)
            {
                Destroy(gameObject);
            }
            lastPos = currPos;
        }
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !isEnemyBullet)
        {
            collision.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
        else if (collision.tag == "Wall")
            Destroy(gameObject);
        else if (collision.tag == "Obstacle")
            Destroy(gameObject);
        else if (collision.tag == "Door")
            Destroy(gameObject);
        else if (collision.tag == "Player" && isEnemyBullet)
        {
            GameController.DamagePlayer(1);
            Destroy(gameObject);
        }
    }
    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }
    
}
