using UnityEngine;
using System.Collections;

public delegate void HintHandler(string hint);

public class HintMouseOver : MonoBehaviour {

    [SerializeField] string hint = "420";

    private int sumValue = 0;

    public int SumValue {
        get { return SumValue; }
        set { sumValue = value; hint = string.Format("The sum of all tiles in this row must equal {0}", sumValue); }
    }

    public static event HintHandler MouseOverHappened;

    void OnMouseOver() {
        if (MouseOverHappened != null) MouseOverHappened(hint);
    }
}
