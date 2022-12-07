using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    [SerializeField] private float destroyDelayTime = 2f;
    [SerializeField] private float scoreTextDelay = 0.5f;
    [SerializeField] float counter = 0;
    [SerializeField] GameObject scoreTextCanvas;

    private float yOffset = 2f;
    public List<GameObject> cubes = new List<GameObject>();
    private GameObject lastBlock;

    

    private void Start()
    {
        LastBlockUpdate();
        scoreTextCanvas.SetActive(false);        
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
            counter++;

            if (cubes.Count > counter)
            {
                DecreasePlayerCube();
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }

    void IncreasePlayerCube(GameObject gameObject)
    {
        PositionOfCube(gameObject);

        scoreTextCanvas.SetActive(true);
        StartCoroutine(ScoreTextChange());
        gameObject.transform.SetParent(transform);
        gameObject.transform.tag = "Player";
        cubes.Add(gameObject);
        LastBlockUpdate();
    }

    void PositionOfCube(GameObject gameObject)
    {
        transform.position = new Vector3(transform.position.x,
                           transform.position.y + yOffset,
                           transform.position.z);

        gameObject.transform.position = new Vector3(lastBlock.transform.position.x,
                                        lastBlock.transform.position.y - yOffset,
                                        lastBlock.transform.position.z);
    }

    IEnumerator ScoreTextChange()
    {
        yield return new WaitForSeconds(scoreTextDelay);
        scoreTextCanvas.SetActive(false);
    }

    void DecreasePlayerCube()
    {
        lastBlock.transform.parent = null;
        cubes.Remove(lastBlock);
        Destroy(lastBlock, destroyDelayTime);
        LastBlockUpdate();
        counter = 0;
    }


    void LastBlockUpdate()
    {
        lastBlock = cubes[cubes.Count - 1];
    }
}
