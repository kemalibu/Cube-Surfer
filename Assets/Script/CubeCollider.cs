using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    private float yOffset = 2f;
    public List<GameObject> cubes = new List<GameObject>();

    private GameObject lastBlock;

    private void Start()
    {
        LastBlockUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            IncreasePlayerCube(other.gameObject);
            other.isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ObstacleCube")
        {
            DecreasePlayerCube();
        }
    }

    void IncreasePlayerCube(GameObject gameObject)
    {
        transform.position = new Vector3(transform.position.x,
                             transform.position.y + yOffset,
                             transform.position.z);

        gameObject.transform.position = new Vector3(lastBlock.transform.position.x,
                                        lastBlock.transform.position.y - yOffset,
                                        lastBlock.transform.position.z);
        gameObject.transform.SetParent(transform);
        gameObject.transform.tag = "Player";
        cubes.Add(gameObject);
        LastBlockUpdate();
    }

    void DecreasePlayerCube()
    {
        lastBlock.transform.parent = null;
        cubes.Remove(lastBlock);
        LastBlockUpdate();
    }

    void LastBlockUpdate()
    {
        lastBlock = cubes[cubes.Count - 1];
    }
}
