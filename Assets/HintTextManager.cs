using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintTextManager : MonoBehaviour {

    [SerializeField] Text hintText;

    void Start() {
        HintMouseOver.MouseOverHappened += new HintHandler(MouseOverHappened);
    }

    void OnDestroy() {
        HintMouseOver.MouseOverHappened -= new HintHandler(MouseOverHappened);
    }

    private void MouseOverHappened(string hint) {
        ChangeText(hint);
    }

    private void ChangeText(string text) {
        hintText.text = text;
    }
}
