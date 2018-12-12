using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class newrathin : MonoBehaviour
{

    // temp2 variable is used to store the distance travelled by the ray.
    public static float temp3 = 0;
    // position variable is used  to get the position value of the component.
    private Transform position;
    //ray variable is used to create ray from starting point to the ending point
    private Ray ray;
    //valueofray variable is used to get the information from the ray variable when it hits anything.
    private RaycastHit valueofray;
    //drawline variable is used to draw the line inorder to trace the path of ray.
    private LineRenderer drawline;
    //direction variable is used to get the direction of the ray reflection.
    private Vector3 direction;
    //noofreflect varible is consists the number of times the reflection is done.
    public int noofreflect = 10;
    // totallength and lineleft variable helps to keep the record of distance travelled by ray when it collides a "playerr". where playerr is a collider
    private float totallength=2500, lineleft = 2500;

    void Start()
    {
        //getting value of the line renderer attached to the given cylinder(a player).
        drawline = this.GetComponent<LineRenderer>();
        //getting value of the position of the player.
        position = this.GetComponent<Transform>();
    }
    void Update()
    {
        //on hitting Space key, it willcalculate the distance travelled by ray through various reflection.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //It is used to set value of number of reflection from-------> 1 to noofreflect=10
            noofreflect = Mathf.Clamp(noofreflect, 1, noofreflect);
            //setting the starting position of the ray and sending it forward.
            ray = new Ray(position.position, position.forward);
            //starting the linerenderer from the origin point.
            drawline.positionCount = 1;
            drawline.SetPosition(0, position.position);

            //it will do the reflection until the noofreflect size.
            //loop breaks if the ray collides with the "playerr" collider.
            for (int i = 0; i < noofreflect; i++)
            {
                //sending the ray if the length does not exceed the max length
                if (Physics.Raycast(ray.origin, ray.direction, out valueofray, lineleft))
                {
                    //calculation the line count
                    drawline.positionCount = drawline.positionCount + 1;
                    //drawing the previous ray line.
                    drawline.SetPosition(drawline.positionCount - 1, valueofray.point);
                    //to set reflected point as origin
                    lineleft = lineleft - Vector3.Distance(ray.origin, valueofray.point);
                    //generating the ray
                    ray = new Ray(valueofray.point, Vector3.Reflect(ray.direction, valueofray.normal));


                    //if reflecting ray hits the "playerr" collider then 
                    //it will  break the loop and store the distance travelled by the ray
                    //in the temp2 global static variable which can be accessed from other script
                    if (valueofray.collider.tag == "playerr")
                    {
                        print("Ray 3");
                        //subtracting the distance of ray left from the total distance.
                        temp3 = totallength - lineleft;
                        break;
                    }

                }
            }
        }
    }
}