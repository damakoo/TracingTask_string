using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetSystem : MonoBehaviour
{
    [SerializeField] public float SettingTime;
    [SerializeField] GameObject Cursor;
    [SerializeField] GameObject Canbus;
    [SerializeField] TextMeshProUGUI InTargetGUI;
    [SerializeField] GameObject Obstacle;
    [SerializeField] public int NumberOfObstacle = 300;
    [SerializeField] float minVelocity = 2;
    [SerializeField] float maxVelocity = 5;
    public List<MoveTarget2> Obstacles = new List<MoveTarget2>();
    private List<bool> alreadyIngnitions = new List<bool>();
    public int CollisionNumber { get; set; } = 0;
    private float nowTime;
    public bool isTracing = false;
    private float Interval;
    public bool isFinished = false;



    // Start is called before the first frame update
    void Start()
    {
        Interval = SettingTime / NumberOfObstacle;
        Canbus.SetActive(false);
        for(int i = 0;i < NumberOfObstacle; i++)
        {
            int theta = Random.Range(0, 360);
            float dx = Random.Range(-1.0f, 1.0f);
            float dy = Random.Range(-1.0f, 1.0f);
            float velocity = Random.Range(minVelocity, maxVelocity);
            GameObject cloneObject = Instantiate(Obstacle, new Vector3(10.0f, i, 0.0f), Quaternion.identity);
            MoveTarget2 _moveTarget = cloneObject.AddComponent<MoveTarget2>();
            _moveTarget.Initialize(new Vector3(Mathf.Cos(theta) * 8, Mathf.Sin(theta) * 8, 0) ,velocity, new Vector3((-1) * Mathf.Cos(theta+dx), (-1) * Mathf.Sin(theta+dy), 0));
            cloneObject.transform.parent = this.transform; // GameManagerを親に指定
            Obstacles.Add(_moveTarget);
            alreadyIngnitions.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTracing)
        {
            isTracing = true;
            Canbus.SetActive(false);

        }
        if (isTracing)
        {
            int n = Mathf.FloorToInt(nowTime / Interval);
            if (!alreadyIngnitions[n])
            {
                Obstacles[n].ignition();
                alreadyIngnitions[n] = true;
            }
            nowTime += Time.deltaTime;
            if (nowTime > SettingTime)
            {
                isTracing = false;
                nowTime = 0;
                Canbus.SetActive(true);
                InTargetGUI.text = CollisionNumber.ToString();
                CollisionNumber = 0;
                Destroy(this.gameObject);
                isFinished = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isTracing = false;
            nowTime = SettingTime;
            CollisionNumber = 0;
        }
    }
}
