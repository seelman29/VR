using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;
using Evereal.VRVideoPlayer;


public class ControllerInput : MonoBehaviour
{
    public Text displayText;
    public Text displayPQ;
    public Text displayDQ;
    public GameObject UITiming;
    public GameObject UIDQ;
    public GameObject UIPQ;
    public GameObject UIRepeatButton;
    public GameObject UINextPitchButton;
    public GameObject UIPreviousPitchButton;
    public float timer = 1f;
    [SerializeField] XRController controller;
    [SerializeField] UnityEvent OnTriggerPressed;
    [SerializeField] UnityEvent OnVideoEnd;
    // double seconds;
    
    bool isPressed;
    double value = 0.00;
    double DQvalue = 0.00;
    int counter = 0;
    
    bool isLooped = false;
    bool loopedWasTrue = false;
    bool video_over = false;
    bool NoSwing = true;
    

    private VRVideoPlayer videoplayer;

    
    IEnumerator Toggle()
    {
        
        while (true)
        {
            VRVideoPlayer x = new VRVideoPlayer();
            isLooped = VRVideoPlayer.looped;
           
            
            if (loopedWasTrue)
            {
                if (isLooped)
                {
                    isLooped = false;
                }
                    
                else
                {
                    isLooped = true;
                    loopedWasTrue = false;
                }
                    
            }
            else
            {
                if (isLooped)
                {
                    isLooped = true;
                    loopedWasTrue = true;
                }
                    
                else
                {
                    isLooped = false;
                }
                    
            }
            
            yield return new WaitForSeconds(0.05f);
            counter++;
            if (video_over)
                counter = 0;
            displayPQ.text = 8.43.ToString();
            controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isPressed);
            if (isPressed)
            {      
                if (counter < 108)
                {
                    displayDQ.text = 3.ToString();
                    DQvalue = 3;
                }   
                if ((counter >= 108) && (counter <= 109))
                {
                    displayDQ.text = 9.99.ToString();
                    DQvalue = 9.99;
                }  
                if(counter == 110)
                {
                    displayDQ.text = 8.88.ToString();
                    DQvalue = 8.88;
                }  
                if (counter == 111)
                {
                    displayDQ.text = 7.77.ToString();
                    DQvalue = 7.77;
                }
                if (counter == 112)
                {
                    displayDQ.text = 6.66.ToString();
                    DQvalue = 6.66;
                }
                if (counter == 113)
                {
                    displayDQ.text = 5.55.ToString();
                    DQvalue = 5.55;
                } 
                if (counter == 114)
                {
                    displayDQ.text = 4.44.ToString();
                    DQvalue = 4.44;
                }  
                if (counter == 115)
                {
                    displayDQ.text = 3.33.ToString();
                    DQvalue = 3.33;
                }
                
                NoSwing = false;

                
                //if (counter < 165)
                //displayText.text = "Early";
                //else if ((counter > 165) && (counter < 167))
                //{
                //displayText.text = "Perfect";
                //}
                //else
                //displayText.text = "Late";


            }
            if(NoSwing)
            {
                displayDQ.text = 3.ToString();
                DQvalue = 3;
            }

            value = (8.43 * 0.25) + (DQvalue * 0.75);
            displayText.text = value.ToString();

            if (counter >= 140)
            {
                counter = 0;
                UITiming.SetActive(true);
                UIDQ.SetActive(true);
                UIPQ.SetActive(true);


                UIRepeatButton.SetActive(true);
                UINextPitchButton.SetActive(true);
                UIPreviousPitchButton.SetActive(true);
                OnTriggerPressed.Invoke();
                OnVideoEnd.Invoke();
                video_over = true;
            }
            /*
            if (isLooped)
            {
                counter = 0;
                UILate.SetActive(false);
                UIPerfect.SetActive(false);
                UIEarly.SetActive(false);
                UIYesSwing.SetActive(false);
                UINoSwing.SetActive(false);



            }
            */

        }
        

            
        
        
        
        //Evereal.VRVideoPlayer.VRVideoPlayer secs = new Evereal.VRVideoPlayer.VRVideoPlayer();
        //seconds = secs.mediaPlayer.time;
        //bool isPressed;
        //UIObject.SetActive(false);
        //controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isPressed);
        //if (isPressed) UIObject.SetActive(true);
        //if(seconds > 6) UIObject.SetActive(true);
    }

    void Start()
    {
       
        UITiming.SetActive(false);
        UIPQ.SetActive(false);
        UIDQ.SetActive(false);
        UIRepeatButton.SetActive(false);
        UINextPitchButton.SetActive(false);
        UIPreviousPitchButton.SetActive(false);
        StartCoroutine(Toggle());
        //VRVideoPlayer x = new VRVideoPlayer();
        //x.Stop();
    }

    public void ClearUI()
    {
        UIRepeatButton.SetActive(false);
        UINextPitchButton.SetActive(false);
    }
}
