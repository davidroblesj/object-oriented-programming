using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public static CameraController instance;
    public RoomInstance currRoom;
    public RoomInstance currRoom1;
    private RoomInstance roomTemporal;
    public float cameraMoveSpeed;
    /*void Awake()
    {
        
        instance = this;
    }*/
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        roomTemporal = currRoom1;
        currRoom1 = currRoom;
        UpdatePosition();
        

    }
    void UpdatePosition()
    {
        if (currRoom == null)
        {
            return;
        }
       
            Vector3 targetPos = GetCameraTargetPosition();
            transform.position = Vector3.MoveTowards(transform.position, targetPos,
                Time.deltaTime * cameraMoveSpeed);
        
        
    }
    Vector3 GetCameraTargetPosition()
    {
        if (currRoom == null)
        {
            return Vector3.zero;
        }
        else if (currRoom != roomTemporal)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerMovement>().lastRoom = currRoom1;
            GameObject level = GameObject.FindGameObjectWithTag("Level");
            /*if (roomTemporal != null)
            {
                print("pinta moradp");
                level.GetComponent<LevelGeneration>().UpdateMap(roomTemporal.theroom, false);
            }*/

            Vector3 targetPos = currRoom.getRoomCentre();
            targetPos.z = transform.position.z;
            return targetPos;
        }
        else
        {
            Vector3 targetPos = currRoom1.getRoomCentre();
            targetPos.z = transform.position.z;
            return targetPos;
        }
    }
}
