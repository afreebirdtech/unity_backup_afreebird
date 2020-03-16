using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //public static void SavePlayer(MonkeyController player)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/player.fun";
    //    FileStream ifs = new FileStream(path,FileMode.Create);

    //    PlayerData data = new PlayerData(player);
    //    formatter.Serialize(ifs, data);
    //    ifs.Close();
    //}

    //public static PlayerData LoadPlayer()
    //{
    //    string path = Application.persistentDataPath + "/player.fun";
    //    if (File.Exists(path))
    //    {
    //        FileStream ifs = new FileStream(path, FileMode.Open);
    //        BinaryFormatter formatter = new BinaryFormatter();

    //        PlayerData data = formatter.Deserialize(ifs) as PlayerData;
    //        ifs.Close();
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogError("Cannot find " + path);
    //        return null;
    //    }
    //}
}
