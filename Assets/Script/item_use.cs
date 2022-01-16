using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_use : MonoBehaviour
{
    public Button[] item_button;
    private Button use_item_button;
    public Text script;
    public GameObject item_panel;

    //착용템은 착용 유무를 bool로 표기할 것
    bool glass_on;
    bool mag_on;

    //public GameObject glasses_panel;
    public GameObject glass_ob;

    public GameObject blur;

    public GameObject script_panel;

    public Camera scenecam;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Button b_item in item_button){
            b_item.onClick.AddListener(delegate { Use_item(b_item); });
        }
        glass_on = false;
        mag_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Use_item(Button butt)
    {
        //Debug.Log("item:"+item_what_i_use+item_on);
        string temp_item = butt.transform.GetChild(1).name;
        Debug.Log(temp_item);
        // 안경에 대해서
        if (temp_item == "item_glasses")
        {
            if (!glass_on)
            {
                using_glasses();
                script.gameObject.SetActive(true);
                script.text = "안경을 사용합니다";
                StartCoroutine(delete_ment());
            }
            else
            {
                script.gameObject.SetActive(true);
                script.text = "안경을 벗었습니다";
                StartCoroutine(delete_ment());
            }
            glass_on = !glass_on;
            
        }
        else if(temp_item == "item_magnifying")
        {
            if (!mag_on)
            {
                scenecam.focalLength = 100;
                glass_ob.SetActive(true);
                script.gameObject.SetActive(true);
                script.text = "돋보기를 사용합니다.";
                StartCoroutine(delete_ment());
            }
            else
            {
                scenecam.focalLength = 50;
                glass_ob.SetActive(false);
                script.gameObject.SetActive(true);
                script.text = "돋보기를 벗었습니다.";
                StartCoroutine(delete_ment());
            }
            mag_on = !mag_on;
        }
        else if (temp_item == "memory")
        {
            item_panel.SetActive(false);
            script_panel.SetActive(true);
            script_panel.SendMessage("Start_memory");
        }

                    //item_panel.transform.Find("glasses").gameObject.SetActive(false);
        

        //Debug.Log(use_item_button.transform.GetChild(0).name+" 을 사용합니다."); //즉 setActive(false)되어 있어도 getchild 시 존재는 인지함을 알 수 있다.
    }
    
    IEnumerator delete_ment()
    {
        yield return new WaitForSeconds(1.0f);
        script.gameObject.SetActive(false);

    }


    //안경 탈착
    void using_glasses()
    {
        //glasses_panel.SetActive(true);
        glass_ob.SetActive(true);
        blur.SetActive(false);

    }
    void take_off_glasses()
    {
        //glasses_panel.SetActive(false);
        glass_ob.SetActive(false);
        blur.SetActive(true);
    }

}
