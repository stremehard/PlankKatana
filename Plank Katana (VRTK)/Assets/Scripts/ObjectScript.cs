using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1.3f, 1.3f);
        Debug.Log(z);
        GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        //Destroy(this.gameObject);
    }
}
