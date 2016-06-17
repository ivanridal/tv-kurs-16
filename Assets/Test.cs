using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test : MonoBehaviour {
    /*
    public Camera leftCamera;
    public Camera rightCamera;

    public Text statusText;

    public OVRCameraRig cameraRig;

    private float ipd;

    public float InterPupillaryDistance
    {
        get
        {
            return ipd;
        }
        set
        {
            ipd = value;
            if (ipd < 0f)
            {
                ipd = 0f;
            }
            leftCamera.transform.localPosition = new Vector3(-ipd / 2f, 0f, 0f);
            rightCamera.transform.localPosition = new Vector3(ipd / 2f, 0f, 0f);
        }
    }
    */
    // Use this for initialization
    void Start () {
        NextMode();
    }

    public Transform ball;

	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0))
        {
            //InterPupillaryDistance += 0.1f * Input.GetAxis("Mouse X");
        }

        //statusText.text = InterPupillaryDistance.ToString();

        ball.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        ball.position += Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            NextMode();
        }
    }

    private int nextMode = 0;

    public Teleport cube;
    public Transform reticle;

    private void NextMode()
    {
        Debug.Log("will set mode " + nextMode);

        switch (nextMode)
        {
            case 0:
                cube.ToggleVRMode();
                
                break;
            case 1:
                cube.ToggleVRMode();
                cube.ToggleDistortionCorrection();
                cube.ToggleDistortionCorrection();
                break;
            case 2:
                cube.ToggleDistortionCorrection();
                break;
            default:
                reticle.gameObject.SetActive(!reticle.gameObject.activeInHierarchy);
                nextMode = 0;
                NextMode();
                return;
        }

        nextMode += 1;
    }

}
