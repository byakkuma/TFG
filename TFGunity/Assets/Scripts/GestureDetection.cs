using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerData;
    public UnityEvent onRecogniced;
}

public class GestureDetection : MonoBehaviour
{
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    public float threshold;
    public bool debugMode = true;
    private List<OVRBone> fingerBones;
    private Gesture previousGesture;
    private Configuration configuration;

    // Start is called before the first frame update
    private void Start()
    {
        configuration = GameObject.FindObjectOfType<Configuration>();
    }

    public void iniciate()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {
        if (configuration.grab.changeMethod.Equals(grabChange.Sign) && fingerBones != null)
        {
            if (debugMode && Input.GetKeyDown(KeyCode.G))
            {
                Save();
            }

            Gesture currentGesture = Recogniced();
            bool hasRecogniced = !currentGesture.Equals(new Gesture());
            if(hasRecogniced && !currentGesture.Equals(previousGesture))
            {
                previousGesture = currentGesture;
                currentGesture.onRecogniced.Invoke();
            } else if (!hasRecogniced)
            {
                previousGesture = new Gesture();
            }
        }
    }

    private void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (OVRBone bone in fingerBones)
        {
            //finger position relative to root
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        g.fingerData = data;
        gestures.Add(g);
    }

    Gesture Recogniced()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;
        foreach(Gesture gesture in gestures){
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerData[i]);
                if(distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }
                sumDistance += distance;
            }
            if(!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }
        return currentGesture;
    }
}
