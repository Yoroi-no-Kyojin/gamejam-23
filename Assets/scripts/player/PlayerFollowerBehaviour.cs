using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerBehaviour : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseValue = Input.GetAxis("Mouse X");
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation += Vector3.up * mouseSensitivity * mouseValue * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position;
    }
}
