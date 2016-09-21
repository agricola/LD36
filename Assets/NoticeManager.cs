using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NoticeManager : MonoBehaviour {

    [SerializeField] GameObject noticePanel;
    [SerializeField] Text noticeText;

    void Awake() {
        TogglePanel(false);
    }

	private void TogglePanel(bool on) {
        noticePanel.SetActive(on);
    }

    public void PressButton() {
        //switch level or something here
        TogglePanel(false);
    }

    public void DisplayNotice(string notice) {
        TogglePanel(true);
        noticeText.text = notice;
    }
}
