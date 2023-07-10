using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherBehaviour : MonoBehaviour
{
    [SerializeField] float minDistance;
    [SerializeField] Transform playerTransform;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 start = new Vector3(), end = new Vector3();
        start.y = end.y = transform.position.y;
        
        for(int i = 0; i < 360; ++i)
        {
            start.x = transform.position.x + minDistance * Mathf.Cos((i - 1) * Mathf.Deg2Rad);
            start.z = transform.position.z + minDistance * Mathf.Sin((i - 1) * Mathf.Deg2Rad);
            end.x = transform.position.x + minDistance * Mathf.Cos(i * Mathf.Deg2Rad);
            end.z = transform.position.z + minDistance * Mathf.Sin(i * Mathf.Deg2Rad);

            Gizmos.DrawLine(start, end);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        Vector3 position = transform.position;
        playerPosition.y = 0;
        position.y = 0;

        if((playerPosition - position).magnitude <= minDistance)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("cinematic-2");
        }
    }
}
