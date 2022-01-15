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
    bool item_on;
    string item_what_i_use;

    public GameObject glasses_panel;
    public GameObject glass_ob;

    public Image blur;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Button b_item in item_button){
            b_item.onClick.AddListener(delegate { Use_item(b_item); });
        }
        item_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Use_item(Button butt)
    {
        Debug.Log("item:"+item_what_i_use+item_on);
        string temp_item = butt.transform.GetChild(1).name;
        Debug.Log(temp_item);
        if (item_on)
        {
            not_use_item();
        }

        // �Ȱ��� ����ϴ� ��
        if (temp_item!= item_what_i_use)
        {
            item_on = true;
            item_what_i_use = temp_item;
            if (temp_item == "glasses")
                {

                    script.gameObject.SetActive(true);
                    script.text = "�Ȱ��� ����մϴ�";
                    StartCoroutine(delete_ment());
                    using_glasses();
                    blur.gameObject.SetActive(false);

                    //item_panel.transform.Find("glasses").gameObject.SetActive(false);
                    
                }
        }
        else
        {
            if (item_what_i_use == "glasses")
            {

                script.gameObject.SetActive(true);
                script.text = "�Ȱ��� �������ϴ�";
                StartCoroutine(delete_ment());
                blur.gameObject.SetActive(true);
                //item_panel.transform.Find("glasses").gameObject.SetActive(false);

            }
            item_what_i_use = "";
        }
        

        //Debug.Log(use_item_button.transform.GetChild(0).name+" �� ����մϴ�."); //�� setActive(false)�Ǿ� �־ getchild �� ����� �������� �� �� �ִ�.
    }

    void not_use_item()
    {
        if (item_what_i_use == "glasses")
        {
            take_off_glasses();
        }


    }
    IEnumerator delete_ment()
    {
        yield return new WaitForSeconds(1.0f);
        script.gameObject.SetActive(false);

    }


    //�Ȱ� Ż��
    void using_glasses()
    {
        glasses_panel.SetActive(true);
        glass_ob.SetActive(true);

    }
    void take_off_glasses()
    {
        glasses_panel.SetActive(false);
        glass_ob.SetActive(false);
    }

}
