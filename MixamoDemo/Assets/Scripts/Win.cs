using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {

    [SerializeField]
    string _message;

    private float _timeTaken;

    private Text _victoryMessage;

    [SerializeField]
    Text _victoryText;

    [SerializeField]
    Text _timeTakenText;

    [SerializeField]
    GameObject _winScreen;

    Timer _timer;

     void Start()
    {
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();    
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _winScreen.SetActive(true);

            _victoryText.text = _message;
            _timeTaken = _timer.getTime();
            string timer = _timeTaken.ToString().Substring(0, 4);
            _timeTakenText.text = "You took " + _timeTaken + " seconds!";

        }
    }
}
