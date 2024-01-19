using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Recorder : MonoBehaviour
{
    bool recording, play;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject ghost;
    [SerializeField]
    Text recordText;

    [SerializeField]
    GhostDataContainer myContainer;

    Vector3 movePos;
    Quaternion moveRot;
    
    // Start is called before the first frame update
    void Start()
    {
        recording = false;
        play = false;
        myContainer = new GhostDataContainer();

        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            recording = !recording;

            if (recording)
            {
                myContainer.Reset();
                ghost.SetActive(false);
                play = false;
            }
            else
            {
                recordText.enabled = false;
                SaveData();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            play = !play;
            recording = false;

            if (play)
            {
                if (myContainer.GetFirstPosition(ref movePos, ref moveRot))
                {
                    SaveData();
                    ghost.SetActive(true);
                    ghost.transform.position = movePos;
                    ghost.transform.rotation = moveRot;
                }
                else
                {
                    play = false;
                }
            }
        }

        
    }

    private void FixedUpdate()
    {
        // The recording and playback are done in the FixedUpdate to ensure the same speed.
        if (recording)
        {
            myContainer.AddPosition(player.transform.position, player.transform.rotation);
            recordText.enabled = true;
        }
        else
        {
            recordText.enabled = false;
        }

        if (play)
        {
            if (myContainer.GetNextPosition(ref movePos, ref moveRot))
            {
                ghost.transform.position = movePos;
                ghost.transform.rotation = moveRot;
            }
            else
            {
                play = false;
            }
        }
    }

    public void SaveData()
    {
        Stream stream = File.Open("Ghost.xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(GhostDataContainer));
        serializer.Serialize(stream, myContainer);
        stream.Close();
    }

    public void LoadData()
    {
        if (File.Exists("Ghost.xml"))
        {
            Stream stream = File.Open("Ghost.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(GhostDataContainer));
            myContainer = serializer.Deserialize(stream) as GhostDataContainer;
            stream.Close();
        }
    }
}
