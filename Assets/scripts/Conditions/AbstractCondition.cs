using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractCondition : MonoBehaviour {


    public abstract GameObject Icon { get; }

    public bool ConditionMet(List<Piece> pieces) {
        bool conditionMet = false;
        foreach (Piece piece in pieces) {
            if (piece) CheckPiece(piece);
        }
        conditionMet = IsConditionMet();

        return conditionMet;
    }

    public abstract void CheckPiece(Piece piece);
    public abstract bool IsConditionMet();


}
