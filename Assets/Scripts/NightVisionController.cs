using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVisionController : MonoBehaviour
{
    public Camera cam;
    public Image zoomBar;
    public Image BatteryChunks;
    public float BatteryLife = 1.0f;
    public float drainTime = 2f;
    void Start()
    {
        zoomBar = GameObject.Find("ZoomBar").GetComponent<Image>();
        BatteryChunks = GameObject.Find("BatteryChunks").GetComponent <Image>();
        cam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        InvokeRepeating("BatteryDrain", drainTime, drainTime);
    }
    private void OnEnable()
    {
        if (zoomBar != null)
            zoomBar.fillAmount = 0.6f;
    }
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(cam.fieldOfView > 10)
            {
                cam.fieldOfView -= 5f;
                zoomBar.fillAmount = cam.fieldOfView / 100;

            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;

            }


        }
        BatteryChunks.fillAmount = BatteryLife;
    }

    public void BatteryDrain()
    {
        if (BatteryLife > 0.0f)
            BatteryLife -= 0.25f;
    }
}
