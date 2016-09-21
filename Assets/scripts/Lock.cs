using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lock : MonoBehaviour {

    [SerializeField] private GameObject slot;
    [SerializeField] private int slotCount;
    [SerializeField] private List<GameObject> slots = new List<GameObject>();
    [SerializeField] private List<GameObject> conditions = new List<GameObject>();
    [SerializeField] private List<Piece> pieces = new List<Piece>();

    Vector3 nextSlotPosition;

    void Start() {
        GenerateConditionIcons();
        GenerateSlots();
    }

	private void GenerateSlots() {

        for (int i = 0; i < slotCount; i++) {
            if (i == 0) { nextSlotPosition.x += 1; }
            else { nextSlotPosition.x += 2; }
            GameObject newSlot = Instantiate(slot, nextSlotPosition, Quaternion.identity) as GameObject;
            newSlot.name = string.Format("Slot{0}", i);
            newSlot.transform.parent = this.gameObject.transform;
            slots.Add(newSlot);
            //
        }
    }

    private void GenerateConditionIcons() {
        nextSlotPosition = transform.position;
        int i = 0;

        foreach (GameObject condition in conditions) {
            AbstractCondition con = condition.GetComponent<AbstractCondition>();
            GameObject newIcon = Instantiate(con.Icon, nextSlotPosition, Quaternion.identity) as GameObject;
            i++;
            nextSlotPosition.x += i;
            newIcon.transform.parent = this.gameObject.transform;
        }
    }

    private void GetPiecesFromSlots() {
        pieces = new List<Piece>();
        foreach (GameObject slot in slots) {
            Piece piece = slot.GetComponent<Slot>().CurrentPiece;
            if (piece != null) pieces.Add(piece);
        }
    }

    private bool ArePiecesEqualToSlots() {
        bool arePiecesEqualToSlots = false;

        if (pieces.Count == slots.Count) arePiecesEqualToSlots = true;

        return arePiecesEqualToSlots;
    }

    public bool CheckConditions() {
        GetPiecesFromSlots();
        //Debug.Log(pieces.Count);
        bool AreAllConditionsMet = false;

        if (ArePiecesEqualToSlots() && pieces.Count > 0) {
            foreach (GameObject conditionObject in conditions) {
                AbstractCondition condition = conditionObject.GetComponent<AbstractCondition>();
                if (condition.ConditionMet(pieces) == false) return AreAllConditionsMet;
            }
            AreAllConditionsMet = true;
        }
        return AreAllConditionsMet;
    }
}
