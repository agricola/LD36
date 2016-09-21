using UnityEngine;
using System.Collections;

public class PieceBin : MonoBehaviour {

    float[] max;
    float[] min;

    bool boundsSet = false;

    void Awake () {
        SetBounds();
    }

    private void SetBounds() {
        if (boundsSet) return;
        Bounds bounds = GetComponent<SpriteRenderer>().bounds;
        max = new float[2] { bounds.max.x, bounds.max.y };
        min = new float[2] { bounds.min.x, bounds.min.y };
        boundsSet = true;
    }

    public bool IsWithinBounds(GameObject other) {
        bool isWithinBounds = false;
        if ((other.transform.position.x > min[0] && other.transform.position.x < max[0]) && (other.transform.position.y > min[1] && other.transform.position.y < max[1])) {
            isWithinBounds = true;
        }

        return isWithinBounds;
    }

    public Vector2 RandomBinPosition(Piece piece) {
        SetBounds();
        Vector2 newPos = Vector2.zero;
        newPos.x = Random.Range(min[0], max[0]);
        newPos.y = Random.Range(min[1], max[1]);
        return newPos;
    }
}
