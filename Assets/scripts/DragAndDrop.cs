using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

    [SerializeField] private bool clicked = false;
    [SerializeField] private DropLocation dropSpot = null;
    [SerializeField] private GameObject pieceBin;

    void Awake() {
        pieceBin = GameObject.Find("bin");
    }

    void Start() {
        SendBackToBin();
    }
	
	void Update () {
        if (clicked) Drag();
	}

    void OnMouseDown() {
        clicked = true;
        ReleasePiece();
    }

    void OnMouseUp() {
        clicked = false;
        DropPiece();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "Slot") return;
        RememberDropSpot(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag != "Slot") return;
        DropLocation dropLocation = other.GetComponent<DropLocation>();

        if (dropSpot == dropLocation) {
            dropSpot = null;
        }
    }

    private void Drag() {
        Vector3 adjustedMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        adjustedMousePosition.z = 10;
        transform.position = adjustedMousePosition;
    }

    private void RememberDropSpot(GameObject dropTarget) {
        DropLocation dropLocation = dropTarget.GetComponent<DropLocation>();

        dropSpot = dropLocation;
    }


    private void DropPiece() {
        if (dropSpot != null) {
            dropSpot.AcceptPiece(GetComponent<Piece>());
        } else {
            if (pieceBin.GetComponent<PieceBin>().IsWithinBounds(this.gameObject)) return;
            else SendBackToBin();
        }
        
    }

    private void ReleasePiece() {
        if (dropSpot != null) {
            dropSpot.ReleasePiece(GetComponent<Piece>());
        } else Debug.Log("release fail");
    }

    public void SendBackToBin() {
        Vector2 newPos = pieceBin.GetComponent<PieceBin>().RandomBinPosition(GetComponent<Piece>());
        transform.position = newPos;
    }
}
