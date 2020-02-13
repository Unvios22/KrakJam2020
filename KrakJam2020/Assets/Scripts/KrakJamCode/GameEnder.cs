using System.Collections;
using UnityEngine;

public class GameEnder : MonoBehaviour{
    [SerializeField] private SceneSwitcher _switcher;
    [SerializeField] int gameLengthInSeconds;
    int _remainingGameTime;

    void Start() {
        _remainingGameTime = gameLengthInSeconds;
        StartCoroutine(CoundownRemainingGameTime());
    }

    IEnumerator CoundownRemainingGameTime() {
        while (RemainingGameTime > 0) {
            yield return new WaitForSeconds(1f);
            _remainingGameTime = RemainingGameTime - 1;
        }
        EndGame();
    }
    
    void EndGame() {
        _switcher.SwitchScene();
    }

    public int RemainingGameTime => _remainingGameTime;
}
