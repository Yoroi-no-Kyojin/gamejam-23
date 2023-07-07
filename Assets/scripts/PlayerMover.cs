using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float walkSpeed, jumpForce;
    [SerializeField] private Transform characterModelTransform, playerFollower;
    [SerializeField] private BoxCollider hitterCollider;
    [SerializeField] private Animator modelAnimator;
    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float axisVertical = Input.GetAxisRaw("Vertical");
        float axisHorizontal = Input.GetAxisRaw("Horizontal");
        float fallSpeed = playerRigidbody.velocity.y;
        Vector3 direction = playerFollower.transform.forward * axisVertical + playerFollower.right * axisHorizontal;
        direction.y = 0;
        playerRigidbody.velocity = direction * walkSpeed + new Vector3(0, fallSpeed, 0);
        float magnitude = Mathf.Sqrt(playerRigidbody.velocity.z * playerRigidbody.velocity.z + playerRigidbody.velocity.x * playerRigidbody.velocity.x);

        if(magnitude > 0.0001f)
        {
            modelAnimator.SetBool("move", true);

            float angle = Mathf.Atan2(playerRigidbody.velocity.z, -playerRigidbody.velocity.x) * Mathf.Rad2Deg - 90;

            Vector3 angleVector3 = characterModelTransform.localRotation.eulerAngles;

            characterModelTransform.localRotation = Quaternion.Euler(angleVector3.x, angle, angleVector3.z);
        }
        else
        {
            modelAnimator.SetBool("move", false);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            modelAnimator.SetTrigger("jump");

            playerRigidbody.AddForce(new Vector3(0, jumpForce, 0));
        }

        if(playerRigidbody.velocity.y < -0.0001f)
        {
            modelAnimator.SetBool("falling", true);
        }
        else
        {
            modelAnimator.SetBool("falling", false);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            modelAnimator.SetTrigger("attack");
        }
    }
}
