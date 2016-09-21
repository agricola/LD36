using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    [SerializeField] GameObject[] locks;
    [SerializeField] GameObject[] pieces;
    List<GameObject> generatedLocks;
    List<GameObject> generatedPieces;

    public void GenerateLevel(GameObject levelManager) {
        generatedLocks = new List<GameObject>();
        generatedPieces = new List<GameObject>();

        Vector3 newPos = levelManager.transform.position;
        int i = 0;
        foreach (GameObject lockObj in locks) {
            newPos.y = levelManager.transform.position.y - (i * 2);
            GameObject newLock = Instantiate(lockObj, newPos, Quaternion.identity) as GameObject;
            generatedLocks.Add(newLock);
            newLock.transform.parent = levelManager.transform;
            i++;
        }

        foreach (GameObject piece in pieces) {
            GameObject newPiece = Instantiate(piece);
            newPiece.GetComponent<DragAndDrop>().SendBackToBin();
            generatedPieces.Add(newPiece);
            newPiece.transform.parent = levelManager.transform;
        }

        //Debug.Log(generatedLocks.Count);
    }

    public void CleanUplevel() {
        foreach (GameObject generatedLock in generatedLocks) {
            Destroy(generatedLock);
        }
        foreach (GameObject generatedPiece in generatedPieces) {
            Destroy(generatedPiece);
        }
        generatedLocks = new List<GameObject>();
        generatedPieces = new List<GameObject>();
    }

    public bool AreAllLocksCorrect() {
        bool success = false;
        foreach (GameObject lockObj in generatedLocks) {
            if (lockObj.GetComponent<Lock>().CheckConditions()) {
                success = true;
                //Debug.Log("passed" + lockObj);
            } else {
                success = false;
                //Debug.Log("failed" + lockObj);
                return success;
                
            }
        }

        return success;
    }
}
