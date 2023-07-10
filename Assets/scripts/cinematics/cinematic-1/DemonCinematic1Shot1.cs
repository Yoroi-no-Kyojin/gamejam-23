using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCinematic1Shot1 : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] ShotBehaviour shotBehaviour;
    private Rigidbody demonRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        demonRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shotBehaviour.gameObject.activeInHierarchy)
        {
            demonRigidbody.velocity = transform.forward * walkSpeed;
        }
        else
        {
            demonRigidbody.velocity = Vector3.zero;
        }
    }
}
