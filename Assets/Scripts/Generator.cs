using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] obj;
    public float minimTiming = 0.5f;
    public float maxTiming = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Invoke("Generate", Random.Range(minimTiming, maxTiming));
    }
}
