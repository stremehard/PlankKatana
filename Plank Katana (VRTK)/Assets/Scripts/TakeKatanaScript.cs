using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeKatanaScript : MonoBehaviour
{
    public GameObject katanaSign;
    public GameObject katanaInHand;
    public GameObject button;
    public GameObject firstThrownObject;
    private bool katanaTouched;

    // Start is called before the first frame update
    void Start()
    {
        katanaTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (katanaTouched)
        {
            if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                katanaSign.SetActive(false);
                katanaInHand.SetActive(true);
                button.SetActive(false);
                firstThrownObject.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="rightController")
        {
            button.SetActive(true);
            katanaTouched = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "rightController")
        {
            button.SetActive(false);
            katanaTouched = false;
        }
    }
}
