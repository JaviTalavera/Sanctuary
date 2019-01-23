using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapGenerator myScript = (MapGenerator)target;
        if (GUILayout.Button("Generate!"))
        {
            GameObject terrain = GameObject.Find("Level_0");
            foreach(Transform child in terrain.transform)
            {
                //if (child.name == "Wall(Clone)")
                    Destroy(child.gameObject);
            }
            Map m = MapGenerator.mapGenerator();
            myScript.Render(m.mapa, terrain.transform, m.GetTpPosition());
        }
    }
}
