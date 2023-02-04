using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] _vCams = new GameObject[2];
    //[SerializeField] private int[] _vCamIds = new int[] { 0, 1 };
    
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            SetActiveVcam(_vCams[0]);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            SetActiveVcam(_vCams[1]);

        }


    }


    void SetActiveVcam(GameObject __vCam)
    {
        for (int i = 0; i < _vCams.Length; i++)
        {
            _vCams[i].gameObject.SetActive(false);
            __vCam.SetActive(true);

        }

    }
}
