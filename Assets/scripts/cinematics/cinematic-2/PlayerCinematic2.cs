using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCinematic2 : MonoBehaviour
{
    [SerializeField] private ShotBehaviour shot2;
    [SerializeField] private Animator animator;
    private bool attacked;

    // Start is called before the first frame update
    void Start()
    {
        attacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!attacked && shot2.gameObject.activeInHierarchy)
        {
            animator.SetTrigger("attack");

            attacked = true;
        }
    }
}
