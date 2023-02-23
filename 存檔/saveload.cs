using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
	
    public static class Saveload{
		public static void SavePlayer (player player){
    
        BinaryFormatter formatter = new BinaryFormatter();
        //Guardamos en un path
        string path = Application.persistentDataPath + "player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
 
		PlayerData data = new PlayerData(player); 
        formatter.Serialize(stream, data);
        stream.Close();
    }

 
    	public static PlayerData LoadPlayer(){   
        string path = Application.persistentDataPath + "player.data";
        //Comprobamos si el archivo existe
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
 
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
 
            return data;
        }
        else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}