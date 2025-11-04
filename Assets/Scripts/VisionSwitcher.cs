using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class VisionSwitcher : MonoBehaviour
{
    public PostProcessVolume vol;
    public PostProcessProfile standard;
    public PostProcessProfile nightVision;
    public GameObject nightVissionOverlay;
    private bool nightVissionOn = false;

    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        nightVissionOverlay.SetActive(false);
        vol.profile = standard;
    }

   

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            if(nightVissionOn == false)
            {
                vol.profile = nightVision;
                nightVissionOn=true;
                nightVissionOverlay.SetActive(true);
                NightVissionOff();
            }
            else if(nightVissionOn == true)
            {
                vol.profile = standard;
                nightVissionOn = false;
                this.gameObject.GetComponent<Camera>().fieldOfView = 60f;
                nightVissionOverlay.SetActive(false);
            }
        }
        if (nightVissionOn == true)
        {
            NightVissionOff();
        }
    }

    public void NightVissionOff()
    {
        if(nightVissionOverlay.GetComponent<NightVisionController>().BatteryLife <= 0)
        {
            vol.profile = standard; 
            nightVissionOverlay.SetActive(false);
            this.gameObject.GetComponent<Camera>().fieldOfView = 60f;
            nightVissionOn = false;
        }
    }
}
