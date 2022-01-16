using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ARcam;
    public GameObject[] Objs;
    internal float dist;//AR카메라랑 물체 사이 거리
    public float Range = 2;

    public Text dist_text;
    private void Awake()
    {
        foreach(GameObject obj in Objs)
        {
            obj.SetActive(false);
        }
        
        if (ARcam == null)
        {
            ARcam = GameObject.Find("AR Camera");
        }
    }

    private void FixedUpdate()
    {
        if (ARcam != null)
        {
            float min_dist = 100;
            int min_thing = 0;

            float dis_x = 0;
            float dis_y = 0;
            float dis_z = 0;

            float fov = ARcam.GetComponent<Camera>().fieldOfView;
            Debug.Log(fov);
            dist_text.text = fov.ToString();
            foreach (GameObject Obj in Objs)
            {
                if (Obj == null)
                {
                    
                }
                else
                {
                    dist = Vector3.Distance(Obj.transform.position, ARcam.transform.position);
                    
                    if (dist < Range)
                    {
                        Obj.SetActive(true);
                        //print(gameObject.name + "has been reached!");
                    }
                    else if (dist > Range)
                    {
                        Obj.SetActive(false);
                    }
                    if (min_dist > dist)
                    {
                        min_dist = dist;
                    }
                }
                
                
            }
            //dist_text.text = min_dist.ToString();


        }
    }
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, Range);
    }
    #endif
}