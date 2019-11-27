using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandlerScript : MonoBehaviour
{
    public GameObject redBigBoat;
    public GameObject redSmallBoat;

    public GameObject blueBigBoat;
    public GameObject blueSmallBoat;

    public Transform redSpawnPosition;
    public Transform blueSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnRedBoat(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnBlueBoat(2);
        }
    }

    public void SpawnRedBoat(int size)
    {
        if (size == 1)
        {
            Instantiate(redSmallBoat, redSpawnPosition.position, Quaternion.identity);
        }
        if (size == 2)
        {
            Instantiate(redBigBoat, redSpawnPosition.position, Quaternion.identity);
        }
    }
    public void SpawnBlueBoat(int size)
    {
        if (size == 1)
        {
            Instantiate(blueSmallBoat, blueSpawnPosition.position, Quaternion.identity);
        }
        if (size == 2)
        {
            Instantiate(blueBigBoat, blueSpawnPosition.position, Quaternion.identity);
        }
    }

    public void MatchOver(string player)
    {
        Debug.Log("Match over!");
    }
}
