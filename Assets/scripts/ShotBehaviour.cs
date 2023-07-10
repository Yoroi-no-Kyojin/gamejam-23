using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotBehaviour : MonoBehaviour
{
    [SerializeField] private OnCinematicEndListener onCinematicEndListener;
    [SerializeField] private ShotBehaviour nextShot;
    [SerializeField] private Vector3 cameraPosition, cameraRotation;
    [SerializeField] private TextMeshProUGUI conversationTextMesh;
    [SerializeField] private Dialog[] dialogs;
    [SerializeField] private float duration;
    private int currentDialog;
    private float startTime, currentTime;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, cameraRotation.z);
        currentDialog = -1;

        NextDialog();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if(duration > 0)
        {
            if(currentTime - startTime >= duration)
            {
                NextShot();
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            NextDialog();
        }
    }

    protected void NextShot()
    {
        if(nextShot == null && onCinematicEndListener != null)
        {
            onCinematicEndListener.Listen();
        }
        else
        {
            nextShot.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void NextDialog()
    {
        ++currentDialog;

        if(currentDialog >= dialogs.Length)
        {
            NextShot();
        }
        else
        {
            conversationTextMesh.text = dialogs[currentDialog].GetSpeaker() + ": " + dialogs[currentDialog].GetDialog();
        }
    }
}
