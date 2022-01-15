using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonevent : MonoBehaviour
{
    // Start is called before the first frame update

    public Button bag_button;
    public GameObject bag_panel;
    private bool bag_active;


    void Start()
    {
        bag_button.onClick.AddListener(Bag_click);
        bag_active = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Bag_click()
    {
        Debug.Log(bag_active);
        if (bag_active)
        {
            bag_panel.SetActive(false);
            bag_active = false;
        }
        else
        {
            bag_panel.SetActive(true);
            bag_active = true;
        }
        

    }
    
}
