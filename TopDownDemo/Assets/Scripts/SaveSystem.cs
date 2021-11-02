using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

  private static string fileName = "/player.data";

  public static void SavePlayer(Player player) {

    // location where to save file
    string path = Application.persistentDataPath + fileName; 
    
    // for formatting and saving the file
    BinaryFormatter formatter = new BinaryFormatter();
    FileStream stream = new FileStream(path, FileMode.Create);

    // data we want to save
    PlayerData data = new PlayerData(player);

    // save the data
    formatter.Serialize(stream, data);
    stream.Close();
    
  }

  public static PlayerData LoadPlayer() {
    
    string path = Application.persistentDataPath + fileName;
    // check to see if theres a file at the path
    if (File.Exists(path)) {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      // get the non-binary data as "player data"
      PlayerData data = formatter.Deserialize(stream) as PlayerData;
      return data;
    } else {
      Debug.LogError("Save file not found in " + path);
      return null;
    }

  }

}