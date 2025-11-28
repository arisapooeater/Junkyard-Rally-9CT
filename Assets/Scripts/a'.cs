using UnityEngine;
using System.Collections;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance{
        get{
            if(_instance == null){
                Debug.log("UI Mgr is NULL");
            }
            return _instance;
        }
        
    }

    void Awake(){
        _instance = this;
    }
    [SerializeField]
    private TextMeshProUGUI _yourScoreText, _theirScoreText;
    private int _yourScore, _theirScore;
    [SerializeField]


    void Start()
    {
       
    }
    public void UpdateYourScore(){
        _yourScore ++;
        _yourScoreText.text = "Your Score: " + _yourScore;
    }
    public void UpdateTheirScore(){
        _theirScore ++;
        _theirScoreText.text = "Their Score: " + _theirScore;
    }
}
