using UnityEngine;
using System.Collections;
using System;

public class AscendingCondition : AbstractCondition {

    [SerializeField] GameObject icon;

    private int oldValue = 0;
    private bool notBroken = true;

    public override GameObject Icon {
        get {
            return icon;
        }
    }

    public override void CheckPiece(Piece piece) {
        int newValue = piece.Value;
        if (newValue <= oldValue) notBroken = false;
        oldValue = newValue;
    }

    public override bool IsConditionMet() {
        bool isConditionMet = false;

        if (notBroken) {
            isConditionMet = true;
        }

        oldValue = 0;
        notBroken = true;

        return isConditionMet;
    }
}
