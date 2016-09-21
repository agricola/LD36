using UnityEngine;
using System.Collections;

public enum PieceColor { Red, Blue, Green}
public enum PieceValue { One, Two, Three, Four}

public class Piece : MonoBehaviour {

    [SerializeField] private PieceColor pieceColor = PieceColor.Red;
    [SerializeField] private PieceValue pieceValue = PieceValue.One;

    [SerializeField] private Sprite[] redSprites;
    [SerializeField] private Sprite[] blueSprites;
    [SerializeField] private Sprite[] greenSprites;

    public PieceColor PieceColor { get { return pieceColor; } }
    public int Value { get { return PieceValueToInt(pieceValue); } }

    void Awake() {
        ChangePiece(pieceColor, pieceValue);
    }

    private void ReplaceSprite(Sprite sprite) {
        SpriteRenderer spriteRenderer;

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprite;
    }

    private Sprite SelectedSprite(PieceColor color, int value) {
        Sprite chosenSprite = null;

        Sprite[] sprites = ColorSprites(color);
        chosenSprite = ValueSprite(value, sprites);

        return chosenSprite;
    }

    private Sprite[] ColorSprites(PieceColor color) {
        Sprite[] sprites = null;

        switch (color) {
            case PieceColor.Red:
                sprites = redSprites;
                break;
            case PieceColor.Blue:
                sprites = blueSprites;
                break;
            case PieceColor.Green:
                sprites = greenSprites;
                break;
            default:
                Debug.Log("No sprite array selected");
                break;
        }

        return sprites;
    }

    private Sprite ValueSprite(int value, Sprite[] sprites) {
        Sprite choseSprite = null;

        if (value >= 1 && value <= 4) {
            choseSprite = sprites[value - 1];
        } else {
            Debug.Log("Sprite value out of range;");
        }

        return choseSprite;
    }

    private int PieceValueToInt(PieceValue value) {
        int numberValue = 1;

        switch (value) {
            case PieceValue.One:
                numberValue = 1;
                break;
            case PieceValue.Two:
                numberValue = 2;
                break;
            case PieceValue.Three:
                numberValue = 3;
                break;
            case PieceValue.Four:
                numberValue = 4;
                break;
            default:
                Debug.Log("Piece Value out of range");
                break;
        }

        return numberValue;
    }

    public void ChangePiece(PieceColor color, PieceValue value) {
        ReplaceSprite(SelectedSprite(color, PieceValueToInt(value)));
    }
}
