using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataValueUI : MonoBehaviour
{

    [SerializeField]
    private Text _label;

    [SerializeField]
    private Text _value;

    [SerializeField]
    private Image _bar;



    public string label {
        get { return _label?.text; }
        set { _label.text = value; }
    }

    public int value {
        get { return int.Parse(_value?.text); }
        set { _value.text = value.ToString(); }
    }

    public float barFill {
        set { _bar.fillAmount = value; }
    }

}
