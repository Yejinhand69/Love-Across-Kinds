using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class NoteSpawn : EditorWindow
{
    public float zPosition;
    string ObjectBaseName01 = "Red Note";
    int ObjectID01 = 1;
    GameObject ObjectToSpawn01;

    string ObjectBaseName02 = "Yellow Note";
    int ObjectID02 = 1;
    GameObject ObjectToSpawn02;

    string ObjectBaseName03 = "Green Note";
    int ObjectID03 = 1;
    GameObject ObjectToSpawn03;

    string ObjectBaseName04 = "Blue Note";
    int ObjectID04 = 1;
    GameObject ObjectToSpawn04;

    [MenuItem("Tools/Note Spawner")]
    public static void ShowWindow()
    {
        GetWindow<NoteSpawn>("Note Spawner");
    }

    private void OnGUI()
    {
        zPosition = EditorGUILayout.FloatField("Y Position", zPosition);

        GUILayout.Label("Spawn Red Note", EditorStyles.boldLabel);

        ObjectBaseName01 = EditorGUILayout.TextField("BaseName", ObjectBaseName01);
        ObjectToSpawn01 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn01, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Red Note"))
        {
            SpawnRedNote();
        }

        GUILayout.Label("Spawn Yellow Note", EditorStyles.boldLabel);

        ObjectBaseName02 = EditorGUILayout.TextField("BaseName", ObjectBaseName02);
        ObjectToSpawn02 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn02, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Yellow Note"))
        {
            SpawnYellowNote();
        }

        GUILayout.Label("Spawn Green Note", EditorStyles.boldLabel);

        ObjectBaseName03 = EditorGUILayout.TextField("BaseName", ObjectBaseName03);
        ObjectToSpawn03 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn03, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Green Note"))
        {
            SpawnGreenNote();
        }

        GUILayout.Label("Spawn Blue Note", EditorStyles.boldLabel);

        ObjectBaseName04 = EditorGUILayout.TextField("BaseName", ObjectBaseName04);
        ObjectToSpawn04 = EditorGUILayout.ObjectField("Prefab To Spawn", ObjectToSpawn04, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Blue Note"))
        {
            SpawnBlueNote();
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

    private void SpawnRedNote()
    {
        if (ObjectToSpawn01 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }

        Vector3 SpawnPos = new Vector3(-32, 1f, zPosition);

        GameObject NewObject = Instantiate(ObjectToSpawn01, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName01 + ObjectID01;

        ObjectID01++;
        zPosition = zPosition + 8;
    }

    private void SpawnYellowNote()
    {
        if (ObjectToSpawn02 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }


        Vector3 SpawnPos = new Vector3(-24, 1f, zPosition);

        GameObject NewObject = Instantiate(ObjectToSpawn02, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName02 + ObjectID02;

        ObjectID02++;
        zPosition = zPosition + 8;
    }

    private void SpawnGreenNote()
    {
        if (ObjectToSpawn03 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }


        Vector3 SpawnPos = new Vector3(-16, 1f, zPosition);

        GameObject NewObject = Instantiate(ObjectToSpawn03, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName03 + ObjectID03;

        ObjectID03++;
        zPosition = zPosition + 8;
    }

    private void SpawnBlueNote()
    {
        if (ObjectToSpawn04 == null)
        {
            Debug.LogError("Error: PLEASE ASSIGN YOUR PREFAB");
            return;
        }


        Vector3 SpawnPos = new Vector3(-8, 1f, zPosition);

        GameObject NewObject = Instantiate(ObjectToSpawn04, SpawnPos, Quaternion.identity);

        NewObject.name = ObjectBaseName04 + ObjectID04;

        ObjectID04++;
        zPosition = zPosition + 8;
    }

    private void SpawnEmptyNote()
    {
        zPosition = zPosition + 8;
    }

    private void ResetID()
    {
        ObjectID01 = 1;
        ObjectID02 = 1;
        ObjectID03 = 1;
        ObjectID04 = 1;

    }
}

#endif