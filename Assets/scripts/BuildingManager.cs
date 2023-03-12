using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BuildingManager : MonoBehaviour {

    public struct Placement {
        public string buildingType;
        public Vector3 position;
        public Quaternion orientation;
        public int level;

        public Placement(string buildingType, Vector3 position,
                         Quaternion orientation, int level) {
            this.buildingType = buildingType;
            this.position = position;
            this.orientation = orientation;
            this.level=level;
        }
    }

    static List<Placement> _placements = new List<Placement>();


    [System.Serializable]
    public struct Buildable {
        public string buildingType;
        public Transform prefab;
    }

    // Use this to set the time period for this scene, so you don't
    // show buildings that haven't been built yet, or buildings that
    // were removed in the past.
    public int level;

    // Populate this in the inspector with the list of prefabs
    // for each building type in this time period.
    public List<Buildable> buildables;

    // Call this to place a new building, and remember it for the future.
    public void Build(string buildingType, Vector3 position, Quaternion orientation) {
        if (Spawn(buildingType, position, orientation) == null )
            return;

        var placement = new Placement(buildingType, position, orientation, level);

        _placements.Add(placement);
    }

    // When the scene loads, spawn prefabs corresponding to each building placed.
    void Awake() {
        foreach (var placement in _placements) {
            if (placement.level == level) 
                continue;
            Spawn(placement.buildingType, placement.position, placement.orientation);
        }
    }        

    // Look up the right prefab for this building, and spawn it.
    // Return null if no prefab has been set up for this type.
    Transform Spawn(string buildingType, Vector3 position, Quaternion orientation) {

        int index = buildables.FindIndex(b => b.buildingType == buildingType);
        if (index < 0) {
            Debug.LogError($"No prefab assigned for the building type {buildingType}");
            return null;
        }

        return Instantiate(buildables[index].prefab, position, orientation);
    } 

}
