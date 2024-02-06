using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveCheckLevel : MonoBehaviour
{
    private string savePath;

    public CheckLevel checkLevel2;
    public CheckLevel checkLevel3;
    public CheckLevel checkLevel4;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/openLevel.dat";
    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        // Tạo một đối tượng lưu trữ dữ liệu cần lưu
        CheckLevelData checkLevelData = new CheckLevelData();
        checkLevelData.isOpenLevel2 = checkLevel2.isOpenLevel;
        checkLevelData.isOpenLevel3 = checkLevel3.isOpenLevel;
        checkLevelData.isOpenLevel4 = checkLevel4.isOpenLevel;

        // Sử dụng BinaryFormatter để ghi dữ liệu vào FileStream
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(savePath);
        binaryFormatter.Serialize(fileStream, checkLevelData);
        fileStream.Close();

        Debug.Log("Open Level successfully.");
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            // Sử dụng BinaryFormatter để đọc dữ liệu từ FileStream
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(savePath, FileMode.Open);
            CheckLevelData checkLevelData = (CheckLevelData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            // Gán dữ liệu
            checkLevel2.isOpenLevel = checkLevelData.isOpenLevel2;
            checkLevel3.isOpenLevel = checkLevelData.isOpenLevel3;
            checkLevel4.isOpenLevel = checkLevelData.isOpenLevel4;
            Debug.Log("Đã tải dữ liệu Open Level thành công.");
        }
        else
        {
            Debug.LogWarning("Không tìm thấy dữ liệu Level đã lưu.");
        }
    }

}
