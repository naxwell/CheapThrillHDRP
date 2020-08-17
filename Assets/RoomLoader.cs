using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Normal.Realtime;

public class RoomLoader : MonoBehaviour
{

    public string roomName;
    private Realtime _realtime;
    public Text _text;
    public GameObject roomCanvas;



    void Awake()
    {
        DontDestroyOnLoad(this);

    }
    // Start is called before the first frame update
    void Start()
    {
        _realtime = GetComponent<Realtime>();
    }

    // Update is called once per frame
    void Update()
    {
        roomName = _text.text;
    }

    public void loadRoom()
    {
        _realtime.Disconnect();
        roomCanvas.SetActive(false);

        _realtime.Connect(roomName);

        //SceneManager.LoadScene(1);
    }
}
