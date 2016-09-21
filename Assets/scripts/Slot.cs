using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

    private BoxCollider2D collider;

    [SerializeField] private int currentValue;
    [SerializeField] private PieceColor currentColor;
    [SerializeField] bool empty = true;
    [SerializeField] Piece currentPiece;


    public Piece CurrentPiece { get { return currentPiece; } }
    public bool Empty { get { return empty; } }

    void Awake() {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        if (empty) { ToggleCollider(true); }
    }

    private void ToggleCollider(bool on) {
        if (on) collider.enabled = true;
        else collider.enabled = false;
    }


    public void UpdatePieceValues(Piece piece) {
        currentPiece = piece;
        if (piece != null) {
            currentValue = piece.Value;
            currentColor = piece.PieceColor;
            empty = false;
            ToggleCollider(false);
        } else {
            empty = true;
            ToggleCollider(true);
        }
    }
}
