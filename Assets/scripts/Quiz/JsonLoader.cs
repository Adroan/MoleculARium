using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class JsonLoader : MonoBehaviour
{
    static string jsonFileName = "Perguntas.json";
    public static Questions LoadFile(){
        Debug.Log(DataPath());
        string conteudoArquivo = File.ReadAllText(DataPath());
        
        JsonReader jsonReader = new JsonReader(conteudoArquivo);
        Questions data = JsonMapper.ToObject<Questions>(jsonReader);
        return data; 
    }

    public static void toJson(Questions questions){
        checkFileExistence(DataPath());
        Debug.Log("estou salvando...");
        JsonData questionJson = JsonMapper.ToJson(questions);
        File.WriteAllText(DataPath(), questionJson.ToString());
        Debug.Log("... salvei");
    }

    public static void backup(){
        checkFileExistence(DataPath());
        string conteudoArquivo = Resources.Load("PerguntasBackup").ToString();
        print(conteudoArquivo);
        JsonReader jsonReader = new JsonReader(conteudoArquivo);
        Questions data = JsonMapper.ToObject<Questions>(jsonReader);
        JsonData questionJson = JsonMapper.ToJson(data);
        File.WriteAllText(DataPath(), questionJson.ToString());
    }

    private static string DataPath(){
        if(Directory.Exists(Application.persistentDataPath)){
            return Path.Combine(Application.persistentDataPath,jsonFileName);
        }
        return Path.Combine(Application.streamingAssetsPath, jsonFileName);
    }

    static void checkFileExistence(string filePath){
        if(!File.Exists(filePath)){
            File.Create(filePath).Close();
        }
    }
    
}
