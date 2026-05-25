using UnityEngine;

[CreateAssetMenu(fileName = "Furniture", menuName = "Scriptable Objects/Furniture")]
public class Furniture : ScriptableObject
{
    public string furnitureName;

    // in case if needed
    public int id;

    public FurnitureType furnitureType;
    public Colours colour;

    public GameObject furniturePrefab;
}
