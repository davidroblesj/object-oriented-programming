using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public static int collectedAmount = 0;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;
    Vector2 shooting;
    public RoomInstance lastRoom;
    public RoomInstance currRoom;

    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        fireDelay = GameController.FireRate;
        moveSpeed = GameController.MoveSpeed;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        animator.SetFloat("Speed", movement.sqrMagnitude);

        shooting.x = Input.GetAxis("ShootHorizontal");
        shooting.y = Input.GetAxis("ShootVertical");
        animator.SetFloat("ShootHorizontal", shooting.x);
        animator.SetFloat("ShootVertical", shooting.y);
        animator.SetFloat("SpeedShooting", shooting.sqrMagnitude);
        if ((shooting.x != 0 || shooting.y != 0)&& Time.time>lastFire+fireDelay)
        {
            Shoot(shooting.x, shooting.y);
            lastFire = Time.time;
            //print(currRoom.gridPos);
            

        }
        



    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement*moveSpeed*Time.fixedDeltaTime);
    }
    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,(y<0)
            ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,0);
    }

}
