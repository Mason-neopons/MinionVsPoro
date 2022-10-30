using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum UI_Order : int
{
    UnitCamScreen = 0,
    HP = 1,
    Skill = 2,
    Item1 = 3,
    Item2 = 4,
    Item3 = 5,
    AD = 6,
    AR = 7
}

public class UnitInfo : MonoBehaviour
{

    public Camera unitCam;
    private RenderTexture rt;
    private Transform unitCamPositionOffset;

    private Slider hpBar;
    private RawImage unitCamScreen;
    private Image skill;
    private Image item1;
    private Image item2;
    private Image item3;
    private Text AD;
    private Text AR;

    private CUnit unit;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {
        hpBar = transform.GetChild((int)UI_Order.HP).GetComponent<Slider>();
        unitCamScreen = transform.GetChild((int)UI_Order.UnitCamScreen).GetComponent<RawImage>();
        skill = transform.GetChild((int)UI_Order.Skill).GetComponent<Image>();
        item1 = transform.GetChild((int)UI_Order.Item1).GetComponent<Image>();
        item2 = transform.GetChild((int)UI_Order.Item2).GetComponent<Image>();
        item3 = transform.GetChild((int)UI_Order.Item3).GetComponent<Image>();
        AD = transform.GetChild((int)UI_Order.AD).GetComponent<Text>();
        AR = transform.GetChild((int)UI_Order.AR).GetComponent<Text>();

        rt = new RenderTexture((int)unitCamScreen.rectTransform.rect.width, (int)unitCamScreen.rectTransform.rect.height, 24);
        unitCam.targetTexture = rt;
        unitCamScreen.texture = rt;
    }

    public void OpenUnit(CUnit _unit)
    {
        unit = _unit;
        hpBar.maxValue = unit.sStatus.hp;
        SetCamPosition(_unit.transform);
        UpdateUnitInfo();
        //Ä«¸Þ¶ó
    }

    public void UpdateUnitInfo()
    {
        hpBar.value = unit.sStatus.hp;
        AD.text = "" + unit.sStatus.damage;
    }

    public void SetCamPosition(Transform targetPosition)
    {
        unitCam.transform.position = targetPosition.position;
    }

    public void CloseUnitInfo()
    {
        
    }
}
