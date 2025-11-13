using UnityEngine;
using UnityEditor;

public class FindMissingScripts : EditorWindow
{
    [MenuItem("Tools/Find Missing Scripts in Scene")]
    public static void FindMissingScriptsInScene()
    {
        int goCount = 0;
        int componentsCount = 0;
        int missingCount = 0;

        GameObject[] go = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject g in go)
        {
            goCount++;
            Component[] components = g.GetComponents<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                componentsCount++;
                if (components[i] == null)
                {
                    missingCount++;
                    Debug.LogWarning($"[Missing Script] GameObject: {g.name} (in scene path: {GetFullPath(g)})", g);
                }
            }
        }

        Debug.Log($"Searched {goCount} GameObjects, {componentsCount} components. Found {missingCount} missing scripts.");
    }

    private static string GetFullPath(GameObject obj)
    {
        return obj.transform.parent == null
            ? obj.name
            : GetFullPath(obj.transform.parent.gameObject) + "/" + obj.name;
    }
}
