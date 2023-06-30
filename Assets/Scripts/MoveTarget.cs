using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] public float SettingTime = 30;
    [SerializeField] GameObject Cursor;
    [SerializeField] GameObject Canbus;
    [SerializeField] GameObject Child;
    [SerializeField] TextMeshProUGUI InTargetGUI;
    [SerializeField] TextMeshProUGUI DistanceGUI;
    private float RestTime;
    private bool isTracing = false;
    SpriteRenderer _SpriteRenderer;
    SpriteRenderer _ChildSpriteRenderer;
    private List<bool> inTarget = new List<bool>();
    private List<float> Distance = new List<float>();
    private float distance_radius;
    
    private float f_x(float t)
    {
        return (3 * Mathf.Sin(1.8f*t/1.5f) + 3.4f * Mathf.Sin(1.8f * t / 1.5f) + 2.5f * Mathf.Sin(1.82f * t / 1.5f) + 4.3f * Mathf.Sin(2.34f * t / 1.5f))/2f;
    }
    private float f_y(float t)
    {
        return (3 * Mathf.Sin(1.1f * t / 1.5f) + 3.2f * Mathf.Sin(3.6f * t / 1.5f) + 3.8f * Mathf.Sin(2.5f * t / 1.5f) + 4.8f * Mathf.Sin(1.48f * t / 1.5f))/2.4f ;
    }
    private float average_distance()
    {
        float average = 0;
        for(int i = 0; i < Distance.Count;i++)
        {
            average += Distance[i];
        }
        return (average / Distance.Count);
    }
    private float average_intarget()
    {
        float average = 0;
        for (int i = 0; i < inTarget.Count; i++)
        {
            if (inTarget[i]) average += 1;
        }
        return (average / inTarget.Count);
    }

    // Start is called before the first frame update
    void Start()
    {
        RestTime = SettingTime;
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        _ChildSpriteRenderer = Child.gameObject.GetComponent<SpriteRenderer>();
        _SpriteRenderer.enabled = true;
        _ChildSpriteRenderer.enabled = true;
        Canbus.SetActive(false);
        distance_radius = this.transform.localScale.x - Cursor.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isTracing)
        {
            isTracing = true;
            _SpriteRenderer.enabled = true;
            _ChildSpriteRenderer.enabled = true;
            Canbus.SetActive(false);

        }
        if(isTracing)
        {
            RestTime -= Time.deltaTime;
            float distancenow = Vector3.Magnitude(this.transform.position - Cursor.transform.position);
            Distance.Add(distancenow);
            inTarget.Add(distancenow<=distance_radius);
            float nowTime = SettingTime - RestTime;
            this.transform.position = new Vector3(f_x(nowTime), f_y(nowTime), 0);
            Child.transform.position = new Vector3(f_x(nowTime), f_y(nowTime), 0);
            if (RestTime < 0)
            {
                isTracing = false;
                this.transform.position = new Vector3(0,0,0);
                RestTime = SettingTime;
                _SpriteRenderer.enabled = false;
                _ChildSpriteRenderer.enabled = false;
                Canbus.SetActive(true);
                InTargetGUI.text = average_intarget().ToString();
                DistanceGUI.text = average_distance().ToString();
                inTarget = new List<bool>();
                Distance = new List<float>();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isTracing = false;
            this.transform.position = new Vector3(0, 0, 0);
            Child.transform.position = new Vector3(0, 0, 0);
            RestTime = SettingTime;
            _SpriteRenderer.enabled = true;
            _ChildSpriteRenderer.enabled = true;
            inTarget = new List<bool>();
            Distance = new List<float>();
        }
    }
}
