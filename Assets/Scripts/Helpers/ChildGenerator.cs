using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildGenerator : MonoBehaviour
{
    [SerializeField] private GameObject childPrefab = null;
    [SerializeField] private int childrenNumber = 0;

    private void OnValidate()
    {
        if(!UnityEditor.PrefabUtility.IsPartOfPrefabAsset(childPrefab)) childPrefab = null;
    }

    [ContextMenu("Generate")]
    private void Generate()
    {
        if (transform.childCount < childrenNumber) InstantiateChildren();
        else if (transform.childCount > childrenNumber) DestroyChildren();
    }

    private void InstantiateChildren()
    {
        int toInstantiate = childrenNumber - transform.childCount;
        for (int i = 0; i < toInstantiate; i++)
        {
            Object child;
            if (!Application.isPlaying) child = UnityEditor.PrefabUtility.InstantiatePrefab(childPrefab, transform);
            else child = Instantiate(childPrefab, transform);
            child.name = childPrefab.name.EndsWith("Prefab") ? childPrefab.name.Substring(0, childPrefab.name.Length - 6) : childPrefab.name;
        }
    }

    private void DestroyChildren()
    {
        int initialChildCount = transform.childCount;
        int toDestroy = transform.childCount - childrenNumber;
        for (int i = 0; i < toDestroy; i++)
        {
            if(!Application.isPlaying) DestroyImmediate(transform.GetChild(initialChildCount - i - 1).gameObject);
            else Destroy(transform.GetChild(initialChildCount - i - 1).gameObject);
        }
    }
}
