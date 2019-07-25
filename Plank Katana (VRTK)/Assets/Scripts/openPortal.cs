using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPortal : MonoBehaviour
{
    private float portalSize;
    private bool portalOpened;

    public GameObject prefab;
    public GameObject blade;
    private int userScore;
    private float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        portalSize = 0.005f;
        portalOpened = false;
        StartCoroutine(Open());
        StartCoroutine(SpawnObjects());
        spawnRate = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(!portalOpened)
        {
            transform.localScale += new Vector3(portalSize, portalSize, portalSize);
        }
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(3);
        portalOpened = true;
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(2.5f);
        while (true)
        {
            Instantiate(prefab, transform.position + new Vector3(0,-0.5f,0), transform.rotation);
            userScore = blade.GetComponent<ExampleUseof_MeshCut>().GetScore();
            Debug.Log("score: " + userScore);
            if (userScore >= 3)
            {
                spawnRate = 2.0f;
            }
            if (userScore >= 7)
            {
                spawnRate = 1.5f;
            }
            if (userScore >= 15)
            {
                spawnRate = 1.0f;
            }
            if (userScore >= 30)
            {
                spawnRate = 0.5f;
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
