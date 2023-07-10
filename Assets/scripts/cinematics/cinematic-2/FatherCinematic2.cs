using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherCinematic2 : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("die");

        if(other.gameObject.layer == 3)
        {
            animator.SetBool("die", true);
        }
    }
}
