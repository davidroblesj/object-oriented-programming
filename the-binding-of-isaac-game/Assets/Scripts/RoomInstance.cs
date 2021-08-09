using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstance : MonoBehaviour
{
    public Texture2D tex;
    [HideInInspector]
    public Vector2 gridPos;
    public int type; // 0: normal, 1: enter
    [HideInInspector]
    public bool doorTop, doorBot, doorLeft, doorRight;
    [SerializeField]
    public GameObject doorU, doorD, doorL, doorR, doorWall;
    [SerializeField]
    ColorToGameObject[] mappings;
    float tileSize = 16;
    Vector2 roomSizeInTiles = new Vector2(9, 17);
	public int numEnemies=10;
	public GameObject items;
	[SerializeField]
	public GameObject ranged,melee;
	public GameObject[] arrayEnemies;
	private bool spawned = false;
	public Room theroom;
	private LevelGeneration theLevelGeneration;
	
	// Start is called before the first frame update
	public void Setup(Texture2D _tex, Vector2 _gridPos, int _type, bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight,Room _theroom)
	{
		tex = _tex;
		gridPos = _gridPos;
		type = _type;
		doorTop = _doorTop;
		doorBot = _doorBot;
		doorLeft = _doorLeft;
		doorRight = _doorRight;
		theroom = _theroom;
		MakeDoors();
		GenerateRoomTiles();
		//SpawnItems();
		SpawnEnemies();
	}

	// Update is called once per frame
	void Update()
	{
		if (numEnemies == 0)
		{
			//Transform room = currRoom.transform;
			Transform doorD = transform.Find("doorD(Clone)");

			Transform doorU = transform.Find("doorU(Clone)");

			Transform doorL = transform.transform.Find("doorL(Clone)");

			Transform doorR = transform.Find("doorR(Clone)");

			if (doorD != null)
			{
				
				doorD.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			}
			if (doorU != null)
			{
				
				doorU.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			}
			if (doorL != null)
			{
			
				doorL.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			}
			if (doorR != null)
			{
				
				doorR.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			}
			if(spawned==false)
			SpawnItems();
			spawned = true;

		}
		else
		{
		
				doorD.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
	
				doorU.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
			
				doorL.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
		
				doorR.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
			
		}
	
	}
	void MakeDoors()
	{
		//top door, get position then spawn
		Vector3 spawnPos = transform.position + Vector3.up * (roomSizeInTiles.y / 4 * tileSize) - Vector3.up * (tileSize / 4);
		PlaceDoor(spawnPos, doorTop, doorU);
		//bottom door
		spawnPos = transform.position + Vector3.down * (roomSizeInTiles.y / 4 * tileSize) - Vector3.down * (tileSize / 4);
		PlaceDoor(spawnPos, doorBot, doorD);
		//right door
		spawnPos = transform.position + Vector3.right * (roomSizeInTiles.x * tileSize)- Vector3.right * (tileSize);
		PlaceDoor(spawnPos, doorRight, doorR);
		//left door
		spawnPos = transform.position + Vector3.left * (roomSizeInTiles.x * tileSize) - Vector3.left * (tileSize);
		PlaceDoor(spawnPos, doorLeft, doorL);
	}
	void PlaceDoor(Vector3 spawnPos, bool door, GameObject doorSpawn)
	{
		// check whether its a door or wall, then spawn
		if (door)
		{
			Instantiate(doorSpawn, spawnPos, Quaternion.identity).transform.parent = transform;
		}
		else
		{
			Instantiate(doorWall, spawnPos, Quaternion.identity).transform.parent = transform;
		}
	}
	void GenerateRoomTiles()
	{
		//loop through every pixel of the texture
		for (int x = 0; x < tex.width; x++)
		{
			for (int y = 0; y < tex.height; y++)
			{
				GenerateTile(x, y);
			}
		}
	}
	void GenerateTile(int x, int y)
	{
		Color pixelColor = tex.GetPixel(x, y);
		//skip clear spaces in texture
		if (pixelColor.a == 0)
		{
			return;
		}
		//find the color to math the pixel
		foreach (ColorToGameObject mapping in mappings)
		{
			if (mapping.color.Equals(pixelColor))
			{
				Vector3 spawnPos = positionFromTileGrid(x, y);
				//Debug.Log(spawnPos);
				Instantiate(mapping.prefab, spawnPos, Quaternion.identity).transform.parent = this.transform;
			}
		
		}
	}
	Vector3 positionFromTileGrid(int x, int y)
	{
		Vector3 ret;
		//find difference between the corner of the texture and the center of this object
		Vector3 offset = new Vector3((-roomSizeInTiles.x + 1) * tileSize, (roomSizeInTiles.y / 4) * tileSize - (tileSize / 4), 0);
		//find scaled up position at the offset
		ret = new Vector3(tileSize * (float)x, -tileSize * (float)y, 0) + offset + transform.position;
		return ret;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Debug.Log("wassaaa");
			GameObject player = GameObject.Find("Player");
			GameObject camera = GameObject.Find("MainCamera");
			player.GetComponent<PlayerMovement>().currRoom = this;
			camera.GetComponent<CameraController>().currRoom = this;
			Vector2 roomDimensions = new Vector2(16 * 17, 16 * 9);
			Vector2 gutterSize = new Vector2(16 * 9, 16 * 4);
			Vector3 pos = new Vector3(this.gridPos.x * (roomDimensions.x + gutterSize.x), this.gridPos.y * (roomDimensions.y + gutterSize.y), 0);
			Debug.Log(pos);
			for(int i=0;i<numEnemies;i++)
			{
				arrayEnemies[i].GetComponent<EnemyController>().currState=EnemyState.Wander;
			}

			print("pinta rojo");
			GameObject.FindGameObjectWithTag("Level").GetComponent<LevelGeneration>().UpdateMap(theroom,true);
			/*for (int i = 0; i < 4; i++)
			{
				for(int j = 0; i < 4; j++)
				{
					
					if(GameObject.FindGameObjectWithTag("Level").GetComponent<LevelGeneration>().rooms[i,j] == null)
					{
						continue;
					}
					else if (theroom == GameObject.FindGameObjectWithTag("Level").GetComponent<LevelGeneration>().rooms[i, j])
					{
						GameObject.FindGameObjectWithTag("Level").GetComponent<LevelGeneration>().rooms[i, j].type = 1;
						GameObject.FindGameObjectWithTag("Level").GetComponent<LevelGeneration>().DrawMap();
					}
				}
			}*/
		}
	}
	
	private void SpawnItems()
	{
		
		//Vector3 pos10 = this.transform.position + new Vector3(x, y, 0);
		Instantiate(items, getRoomCentre(), Quaternion.identity).transform.parent = transform;

	}
	private void SpawnEnemies()
	{
		float y = Random.Range(-1 * (roomSizeInTiles.y / 5 * tileSize - (tileSize / 5)), roomSizeInTiles.y / 5 * tileSize - (tileSize / 5));
		float x = Random.Range(-1 * (roomSizeInTiles.x * tileSize) + (tileSize), (roomSizeInTiles.x * tileSize) - 2 * (tileSize));
		Vector3 pos10 = this.transform.position + new Vector3(x, y, 0);
		int randum = Random.Range(0, 1);
		numEnemies = Random.Range(1, 5);
		arrayEnemies = new GameObject[numEnemies];
		//print(numEnemies);
		if (randum == 0)
		{
			
			arrayEnemies[0] = Instantiate(melee, pos10, Quaternion.identity) as GameObject;
			arrayEnemies[0].transform.parent = transform;
			arrayEnemies[0].GetComponent<EnemyController>().Room = this.gameObject;
		}
		else
		{

			arrayEnemies[0] = Instantiate(ranged, pos10, Quaternion.identity) as GameObject;
			arrayEnemies[0].transform.parent = transform;
			arrayEnemies[0].GetComponent<EnemyController>().Room = this.gameObject;
		}
		//Instantiate(melee, pos10, Quaternion.identity).transform.parent = transform;
		//print(Physics2D.OverlapBox(pos10, new Vector2(1, 1), 1).gameObject.name);
		
		for (int i = 1; i < numEnemies; i++)
		{
			y = Random.Range(-1 * (roomSizeInTiles.y / 5 * tileSize - (tileSize / 5)), roomSizeInTiles.y / 5 * tileSize - (tileSize / 5));
			x = Random.Range(-1 * (roomSizeInTiles.x * tileSize) + (tileSize), (roomSizeInTiles.x * tileSize) - (tileSize));
			pos10 = this.transform.position + new Vector3(x, y, 0);
			randum = Random.Range(0, 2);
			if (randum == 0)
			{
				//print("melee");

				arrayEnemies[i] = Instantiate(melee, pos10, Quaternion.identity) as GameObject;
				arrayEnemies[i].transform.parent = transform;
				arrayEnemies[i].GetComponent<EnemyController>().Room = this.gameObject;
			}
			else
			{
				//print("ranged");
				arrayEnemies[i] = Instantiate(ranged, pos10, Quaternion.identity) as GameObject;
				arrayEnemies[i].transform.parent = transform;
				arrayEnemies[i].GetComponent<EnemyController>().Room = this.gameObject;
			}

		}
		
	}
	
		public Vector3 getRoomCentre()
	{
		Vector2 roomDimensions = new Vector2(16 * 17, 16 * 9);
		Vector2 gutterSize = new Vector2(16 * 9, 16 * 4);
		Vector3 centre = new Vector3(this.gridPos.x * (roomDimensions.x + gutterSize.x), this.gridPos.y * (roomDimensions.y + gutterSize.y));
		return centre;
	}
}
