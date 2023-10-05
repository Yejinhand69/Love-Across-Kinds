using UnityEngine;
using UnityEditor;

public class NoteSpawn : EditorWindow
{
    public float yPosition;
    string ObjectBaseName01 = "Blue Note";
    int ObjectID01 = 1;
    GameObject ObjectToSpawn01;

    string ObjectBaseName02 = "Red Note";
    int ObjectID02 = 1;
    GameObject ObjectToSpawn02;

    string ObjectBaseName03 = "Yellow Note";
    int ObjectID03 = 1;
    GameObject ObjectToSpawn03;

    string ObjectBaseName04 = "Green Note";
    int ObjectID04 = 1;
    GameObject ObjectToSpawn04;

    [MenuItem("Tools/Note Spawner")]
    public static void ShowWindow()
    {
        GetWindow<NoteSpawn>("Note Spawner");
    }

    private void OnGUI()
    {
        yPosition = EditorGUILayout.FloatField("Y Position", yPosition);

        GUILayout.Label("Spawn Blue Note", EditorStyles.boldLabel);

        ObjectBaseName01 = EditorGUILayout.TextField("BaseName", ObjectBaseName01);
        ObjectID01 = EditorGUILayout.IntField("GameObject ID", ObjectID01);
        ObjectToSpawn01 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn01, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Blue Note"))
        {
            SpawnBlueNote();
        }

        GUILayout.Label("Spawn Red Note", EditorStyles.boldLabel);

        ObjectBaseName02 = EditorGUILayout.TextField("BaseName", ObjectBaseName02);
        ObjectID02 = EditorGUILayout.IntField("GameObject ID", ObjectID02);
        ObjectToSpawn02 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn02, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Red Note"))
        {
            SpawnRedNote();
        }

        GUILayout.Label("Spawn Yellow Note", EditorStyles.boldLabel);

        ObjectBaseName03 = EditorGUILayout.TextField("BaseName", ObjectBaseName03);
        ObjectID03 = EditorGUILayout.IntField("GameObject ID", ObjectID03);
        ObjectToSpawn03 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn03, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Yellow Note"))
        {
            SpawnYellowNote();
        }

        GUILayout.Label("Spawn Green Note", EditorStyles.boldLabel);

        ObjectBaseName04 = EditorGUILayout.TextField("BaseName", ObjectBaseName04);
        ObjectID04 = EditorGUILayout.IntField("GameObject ID", ObjectID04);
        ObjectToSpawn04 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn04, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Green Note"))
        {
            SpawnGreenNote();
        }

        GUILayout.Label("Spawn Empty Note", EditorStyles.boldLabel);

        if (GUILayout.Button("Spawn Empty Note"))
        {
            SpawnEmptyNote();
        }

        GUILayout.Label("Reset GameObjectID", EditorStyles.boldLabel);

        if (GUILayout.Button("Reset"))
        {
            ResetID();
        }
    }

    private void SpawnBlueNote()
    {
        if (ObjectToSpawn01 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }

        Vector3 SpawnPos = new Vector3(-3f, yPosition, 0f);

        GameObject NewObject = Instantiate(ObjectToSpawn01, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName01 + ObjectID01;

        ObjectID01++;
        yPosition++;
    }

    private void SpawnRedNote()
    {
        if (ObjectToSpawn02 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }


        Vector3 SpawnPos = new Vector3(-1f, yPosition, 0f);

        GameObject NewObject = Instantiate(ObjectToSpawn02, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName02 + ObjectID02;

        ObjectID02++;
        yPosition++;
    }

    private void SpawnYellowNote()
    {
        if (ObjectToSpawn03 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }


        Vector3 SpawnPos = new Vector3(1f, yPosition, 0f);

        GameObject NewObject = Instantiate(ObjectToSpawn03, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName03 + ObjectID03;

        ObjectID03++;
        yPosition++;
    }

    private void SpawnGreenNote()
    {
        if (ObjectToSpawn04 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }


        Vector3 SpawnPos = new Vector3(3f, yPosition, 0f);

        GameObject NewObject = Instantiate(ObjectToSpawn04, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName04 + ObjectID04;

        ObjectID04++;
        yPosition++;
    }

    private void SpawnEmptyNote()
    {
        yPosition++;
    }

    private void ResetID()
    {
        ObjectID01 = 1;
        ObjectID02 = 1;
        ObjectID03 = 1;
        ObjectID04 = 1;

    }
}