using UnityEngine;
using System.Collections;

public class DropLocation : MonoBehaviour {

    [SerializeField] Piece currentPiece;

    public Piece CurrentPiece { get { return currentPiece; } }

    private void UpdateSlotValues(Piece piece) {
        Slot slot = GetComponent<Slot>();
        if (slot) slot.UpdatePieceValues(piece);
    }

    private void RejectPiece(Piece piece) {
        //reject piece
        piece.GetComponent<DragAndDrop>().SendBackToBin();
    }

	public void AcceptPiece(Piece piece) {
        if (!GetComponent<Slot>().Empty) {
            RejectPiece(piece);
            //Debug.Log("piece rejected!");
            return;
        }
        currentPiece = piece;
        piece.transform.position = transform.position;
        UpdateSlotValues(piece);
        GameObject.Find("placement").GetComponent<AudioSource>().Play();
        //Debug.Log("piece accepted");
    }

    public void ReleasePiece(Piece piece) {
        currentPiece = null;
        //Debug.Log("piece released");
        UpdateSlotValues(null);
    }



}
