using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenManager : MonoBehaviour
{
    public Camera cam1, cam2, cam3, cam4;

    private int camNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (camNumber < 4)
            {
                camNumber = camNumber + 1;
            }
            SetSplitScreen();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (camNumber > 1)
            {
                camNumber = camNumber - 1;
            }
            SetSplitScreen();
        }
    }

    public void SetSplitScreen()
    {
        Debug.Log(camNumber);
        switch (camNumber)
        {
            case 1:
                cam2.enabled = false;
                cam3.enabled = false;
                cam4.enabled = false;

                cam1.rect = new Rect(0f, 0f, 1f, 1f);

                break;
            case 2:
                cam2.enabled = true;
                cam3.enabled = false;
                cam4.enabled = false;

                cam1.rect = new Rect(0f, 0f, .5f, 1f);
                cam2.rect = new Rect(.5f, 0f, .5f, 1f);

                break;
            case 3:
                cam2.enabled = true;
                cam3.enabled = true;
                cam4.enabled = false;

                cam1.rect = new Rect(0f, .5f, .5f, .5f);
                cam2.rect = new Rect(.5f, .5f, .5f, .5f);
                cam3.rect = new Rect(.25f, 0f, .5f, .5f);

                break;
            case 4:
                cam2.enabled = true;
                cam3.enabled = true;
                cam4.enabled = true;

                cam1.rect = new Rect(0f, .5f, .5f, .5f);
                cam2.rect = new Rect(.5f, .5f, .5f, .5f);
                cam3.rect = new Rect(0f, 0f, .5f, .5f);

                break;
        }
    }
}
