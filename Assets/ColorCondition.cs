using UnityEngine;
using System.Collections;

public class ColorCondition : AbstractCondition {


    [SerializeField] GameObject redBlueIcon;
    [SerializeField] GameObject redGreenIcon;
    [SerializeField] GameObject greenBlueIcon;

    [SerializeField] PieceColor color0;

    [SerializeField] PieceColor color1;

    [SerializeField] bool allCorrectColor = true;

    public override GameObject Icon {
        get {
            return DoubleColorIcon();
        }
    }

    private GameObject DoubleColorIcon() {
        GameObject icon = null;
        if (color0 == PieceColor.Red) {
            if (color1 == PieceColor.Blue) icon = redBlueIcon;
            if (color1 == PieceColor.Green) icon = redGreenIcon;
        } else if (color0 == PieceColor.Blue) {
            if (color1 == PieceColor.Red) icon = redBlueIcon;
            if (color1 == PieceColor.Green) icon = greenBlueIcon;
        } else if (color0 == PieceColor.Green) {
            if (color1 == PieceColor.Red) icon = redGreenIcon;
            if (color1 == PieceColor.Blue) icon = greenBlueIcon;
        }

        return icon;
    }

    public override void CheckPiece(Piece piece) {
        PieceColor color = piece.PieceColor;
        if (color == color0 || color == color1) return;
        else allCorrectColor = false;
    }

    public override bool IsConditionMet() {
        bool isConditionMet = allCorrectColor;

        return isConditionMet;
    }

}
