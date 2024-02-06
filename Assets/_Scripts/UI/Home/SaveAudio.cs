using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveAudio : MonoBehaviour
{
    private string savePath;

    public ScriptableObjectAudio music;
    public ScriptableObjectAudio FX;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/audioData.dat";
    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        // Tạo một đối tượng lưu trữ dữ liệu cần lưu
        AudioData audioData = new AudioData();
        audioData.musicValue = music.audioVolume;
        audioData.FXValue = FX.audioVolume;

        // Sử dụng BinaryFormatter để ghi dữ liệu vào FileStream
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(savePath);
        binaryFormatter.Serialize(fileStream, audioData);
        fileStream.Close();

        Debug.Log("Saved Audio successfully.");
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            // Sử dụng BinaryFormatter để đọc dữ liệu từ FileStream
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(savePath, FileMode.Open);
            AudioData audioData = (AudioData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            // Gán dữ liệu
            music.audioVolume = audioData.musicValue;
            FX.audioVolume = audioData.FXValue;
            Debug.Log("Loaded Audio successfully.");
        }
        else
        {
            Debug.LogWarning("No saved Audio data found.");
        }
    }
}
