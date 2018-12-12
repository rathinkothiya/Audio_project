using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movingobject : MonoBehaviour
{
    AudioSource audioData;
    AudioEchoFilter echofilter;
    float temp4,temp5,temp6,value2;
    int value1;
    public List<float> distance;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        echofilter = GetComponent<AudioEchoFilter>();
    }
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * 0.01f * 150.0f;
        var z = Input.GetAxis("Vertical") * 0.01f * 10.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            StartCoroutine(Example());
            
            temp4 = rathin2.temp1;
            temp5 = rathin1.temp2;
            temp6 = newrathin.temp3;
             distance= new List<float>();
            distance.Add(temp4);
            distance.Add(temp5);
            distance.Add(temp6);
           
            distance.Sort();
            int counter1 = 0;

            for (int i = 0;i<3 ; i++) {

                if (distance[i] <= 34.3)
                {
                }
                else
                {

                    value1 = Mathf.RoundToInt(distance[i] * 1000 / 343);

                    GetComponent<AudioEchoFilter>().delay = value1;
                    value2 = distance[i];
                    value2 = (float)value2 / (float)49.314/(float)100;
                    value2 = (float)0.5 - value2;

                    GetComponent<AudioEchoFilter>().decayRatio = value2;
                    counter1 = counter1 + 1;
                    print(distance[i]);
                    audioData.Play(0);
                    
                }
            }
            if (counter1 == 0)
            {
                echofilter.enabled = false;
                audioData.Play(0);
            }


            

        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
    }
}