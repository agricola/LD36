using UnityEngine;
using System.Collections;
using System;


public class SumCondition : AbstractCondition {


    [SerializeField] GameObject icon;

    [SerializeField] private int targetSum = 4;
    [SerializeField] private int piecesSum = 0;

    public int TargetSum { get { return targetSum; } }

    public override GameObject Icon {
        get {
            return icon;
        }
    }

    void Awake() {
        icon.GetComponent<HintMouseOver>().SumValue = targetSum;
    }

    public override void CheckPiece(Piece piece) {
        piecesSum += piece.Value;
    }

    public override bool IsConditionMet() {
        bool isConditionMet = false;

        if (piecesSum == targetSum) {
            isConditionMet = true;
        }
        piecesSum = 0;
        return isConditionMet;
    }

}
