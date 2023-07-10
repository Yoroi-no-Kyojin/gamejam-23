using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] Transform playerTransform, fatherTransform;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        Vector3 fatherPosition = fatherTransform.position;
        playerPosition.y = fatherPosition.y = 0;
        Vector3 direction = (fatherPosition - playerPosition).normalized;
        float angle = Vector3.SignedAngle(direction, playerTransform.forward, Vector3.up);

        rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
