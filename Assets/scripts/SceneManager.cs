using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private float minDistance;
    [SerializeField] private Transform playerTransform;
    private GameObject[] terrains;

    // Start is called before the first frame update
    void Start()
    {
        terrains = GameObject.FindGameObjectsWithTag("terrain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
