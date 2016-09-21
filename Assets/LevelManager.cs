using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    [SerializeField] NoticeManager noticeManager;
    [SerializeField] List<GameObject> levels = new List<GameObject>();

    void Start() {
        StartCurrentLevel();
        noticeManager.DisplayNotice("You are in ancient ruins of a strangely advanced civilization. Each door has a puzzle to open it. Fill all the slots then press execute. Hint text is on the left.");
    }

    private void StartCurrentLevel() {
        levels[0].GetComponent<Level>().GenerateLevel(this.gameObject);
    }

    private void CleanUpCurrentLevel() {
        levels[0].GetComponent<Level>().CleanUplevel();
    }

    private void GoToNextLevel() {
        CleanUpCurrentLevel();
        levels.RemoveAt(0);
        GameObject.Find("finish_level").GetComponent<AudioSource>().Play();
        if (levels.Count == 0) noticeManager.DisplayNotice("You have reached the final room of the ruins. It is filled with gold!");
        else StartCurrentLevel();
    }

    public void TestConditions() {
        if (levels[0].GetComponent<Level>().AreAllLocksCorrect()) {
            noticeManager.DisplayNotice("You have opened the door.");
            GoToNextLevel();
        } else {
            noticeManager.DisplayNotice("You failed");
        }
    }
}
