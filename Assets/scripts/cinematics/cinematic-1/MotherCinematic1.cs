using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCinematic1 : MonoBehaviour
{
    [SerializeField] private GameObject shot1, shot3, modelIdle, modelDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shot1.activeInHierarchy)
        {
            modelIdle.SetActive(true);
            modelDead.SetActive(false);
        }

        if(shot3.activeInHierarchy)
        {
            modelDead.SetActive(true);
            modelIdle.SetActive(false);
        }
    }
}
