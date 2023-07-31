using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PointSetting_const : MonoBehaviour
{
    [SerializeField] SendToServer _SendToServer;
    private bool isAnten = false;
    public int collidetime = 0;
    [SerializeField] Transform DeadlineSize;
    [SerializeField] Image image;
    List<GameObject> DeadlineUpper = new List<GameObject>();
    List<GameObject> DeadlineLower = new List<GameObject>();
    List<GameObject> DeadlineRight = new List<GameObject>();
    List<GameObject> DeadlineLeft = new List<GameObject>();
    [SerializeField] GameObject DeadlinePoint;
    [SerializeField] Transform Cursor;
    Rigidbody2D _cursorRigidbody;
    private List<LineRenderer> UpperLine = new List<LineRenderer>();
    private List<LineRenderer> LowerLine = new List<LineRenderer>();
    private List<LineRenderer> RightLine = new List<LineRenderer>();
    private List<LineRenderer> LeftLine = new List<LineRenderer>();
    private List<PolygonCollider2D> Uppercollider = new List<PolygonCollider2D>();
    private List<PolygonCollider2D> Lowercollider = new List<PolygonCollider2D>();
    private List<PolygonCollider2D> Rightcollider = new List<PolygonCollider2D>();
    private List<PolygonCollider2D> Leftcollider = new List<PolygonCollider2D>();
    [SerializeField] float defaultcolor = 0.7f;
    [SerializeField] Material red;
    [SerializeField] Material white;
    [SerializeField] Material cursorcolor;
    [SerializeField] MoveTarget _MoveTarget;
    private bool isSettingline = false;
    [SerializeField] int AppearLine = 4;
    [SerializeField] MoveCursor2 _MoveCursor;
    private bool isSettingTriger = false;
    [SerializeField] GameObject RightCursor;
    [SerializeField] GameObject LeftCursor;
    [SerializeField] GameObject RopeParent;
    List<Transform> RopeChildrenTransform = new List<Transform>();
    List<Vector3> RopeChildrenfirstPosition = new List<Vector3>();
    List<Quaternion> RopeChildrenfirstQuaternion = new List<Quaternion>();
    private Vector3 firstCursorPos;
    private Vector3 firstRightCursorPos;
    private Vector3 firstLeftCursorPos;
    private Quaternion firstCursorRot;
    private Quaternion firstRightCursorRot;
    private Quaternion firstLeftCursorRot;
    private int IgniteTime = 0;
    List<int> numbers = new List<int>();
    List<int> Ignitenumbers = new List<int>();
    public bool CanMoveBall = true;
    [SerializeField] GameObject whiteUi;
    [SerializeField] GameObject redUi;
    [SerializeField] TextMeshProUGUI OneResult;
    [SerializeField] float resttime = 6;
    [SerializeField] float showwhitetime = 4;
    private float nowresttime = 0;
    private bool isResting = false;
    private bool beappearui = false;
    private bool befadewhiteui = false;
    private bool befaderedui = false;

[SerializeField] TextMeshProUGUI _collisionUI;
    private Vector2[] _upperline1 = new Vector2[]
    {
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
    };
    private Vector2[] _upperline2 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _upperline3 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _upperline4 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _upperline5 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _upperline6 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};

    private Vector2[] _upperline7 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _upperline8 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _rightline1 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _rightline2 = new Vector2[]
    {
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
    };
    private Vector2[] _rightline3 = new Vector2[]
    {
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
    };
    private Vector2[] _rightline4 = new Vector2[]
    {
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
    };
    private Vector2[] _rightline5 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};
    private Vector2[] _rightline6 = new Vector2[]
{
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
        Vector2.zero,
};

    int _upperpoint1;
    int _upperpoint2;
    int _upperpoint3;
    int _upperpoint4;
    int _upperpoint5;
    int _upperpoint6;
    int _upperpoint7;
    int _upperpoint8;

    int _lowerpoint1;
    int _lowerpoint2;
    int _lowerpoint3;
    int _lowerpoint4;
    int _lowerpoint5;
    int _lowerpoint6;
    int _lowerpoint7;
    int _lowerpoint8;

    int _rightpoint1;
    int _rightpoint2;
    int _rightpoint3;
    int _rightpoint4;
    int _rightpoint5;
    int _rightpoint6;

    int _leftpoint1;
    int _leftpoint2;
    int _leftpoint3;
    int _leftpoint4;
    int _leftpoint5;
    int _leftpoint6;

    [SerializeField] int Number_rightleft = 5;
    [SerializeField] int Number_updown = 10;
    private Vector3 minRange
    {
        get
        {
            return new Vector3(DeadlineSize.position.x - DeadlineSize.localScale.x / 2f, DeadlineSize.position.y - DeadlineSize.localScale.y / 2f, DeadlineSize.position.z - DeadlineSize.localScale.z / 2f);
        }
    }
    private Vector3 maxRange
    {
        get
        {
            return new Vector3(DeadlineSize.position.x + DeadlineSize.localScale.x / 2f, DeadlineSize.position.y + DeadlineSize.localScale.y / 2f, DeadlineSize.position.z + DeadlineSize.localScale.z / 2f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        whiteUi.SetActive(false);
        redUi.SetActive(false);
        RopeInitialize();
        Initialize();
        _collisionUI.text = "";
        SpawnChild();
        for (int i = 0; i < 20; i++)
        {
            //numbers.Add(i);
            numbers.Add(i);
        }

        while (numbers.Count > 0)
        {

            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];
            Ignitenumbers.Add(ransu);
            numbers.RemoveAt(index);
        }
        _cursorRigidbody = Cursor.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_MoveTarget.isTracing)
        {
            isResting = true;
        }
        /*if (isAnten) AddAnten();
        if (isSettingTriger)
        {
            isSettingTriger = false;
            fadecollider();
            if (_MoveCursor.CollideDeadline)
            {
                collidetime += 1;
                for (int i = 0; i < (_SendToServer.TrialList.Count - _SendToServer.SucceededList.Count); i++)
                {
                    _SendToServer.SucceededList.Add(false);
                }
                Debug.Log(_SendToServer.TrialList.Count == _SendToServer.SucceededList.Count);
                _MoveCursor.CollideDeadline = false;
                Invoke(nameof(CursorOff), 0.3f);
                Invoke(nameof(CursorOn), 0.4f);
                Invoke(nameof(CursorOff), 0.5f);
                Invoke(nameof(CursorOn), 0.6f);
                Invoke(nameof(CursorOff), 0.7f);
                Invoke(nameof(CursorOn), 0.8f);
            }
            else
            {
                for (int i = 0; i < (_SendToServer.TrialList.Count - _SendToServer.SucceededList.Count); i++)
                {
                    _SendToServer.SucceededList.Add(true);
                }

                Debug.Log(_SendToServer.TrialList.Count == _SendToServer.SucceededList.Count);
            }
        }


        if (_MoveTarget.isTracing)
        {
            if (_MoveTarget.RestTime % 4 < AppearLine - 1 && !_MoveTarget.isFinishied)
            {
                if (!isSettingline)
                {
                    setline(Ignitenumbers[IgniteTime]);
                    IgniteTime += 1;
                    isSettingline = true;
                }
                else
                {
                    minusColor();
                    //setCollider();
                }
                /*_SendToServer.TrialList.Add(IgniteTime - 1);
                _SendToServer.RestTimeList.Add(_MoveTarget.RestTime % 4);
                _SendToServer.LeftInputList.Add((Input.GetKey(KeyCode.W)) ? 1 : ((Input.GetKey(KeyCode.S)) ? -1 : 0));
                _SendToServer.RightInputList.Add((Input.GetKey(KeyCode.UpArrow)) ? 1 : ((Input.GetKey(KeyCode.DownArrow)) ? -1 : 0));
                _SendToServer.LeftPosList.Add(LeftCursor.transform.position);
                _SendToServer.RightPosList.Add(RightCursor.transform.position);
                _SendToServer.TargetPosList.Add(Cursor.transform.position);
                _SendToServer.LineNumList.Add(Ignitenumbers[IgniteTime - 1]);
                _SendToServer.ErrorNumList.Add(collidetime);

            }
            else if (_MoveTarget.RestTime % 4 > 3f && _MoveTarget.RestTime < 37 && isSettingline)
            {
                _MoveTarget.isTracing = false;
                setCollider();
                Ignition();
                isSettingline = false;
                isSettingTriger = true;
                Invoke(nameof(ResetMaterial), 0.2f);
                Invoke(nameof(Anten), 0.2f);
                Invoke(nameof(RestartTracing), 1.2f);
            }

        }

        if (_MoveTarget.isFinishied)
        {
            _MoveTarget.isFinishied = false;
            Ignition();
            isSettingline = false;
            setCollider();
            isSettingTriger = true;
            Invoke(nameof(ResetMaterial), 0.2f);
            Invoke(nameof(UpdateUI),0.4f);
        }*/

    }
    void FixedUpdate()
    {
        if (isAnten) AddAnten();
        if (isSettingTriger)
        {
            isSettingTriger = false;
            fadecollider();
            if (_MoveCursor.CollideDeadline)
            {
                OneResult.text = "Failed";
                collidetime += 1;
                int j = _SendToServer.TrialList.Count - _SendToServer.SucceededList.Count;
                for (int i = 0; i < j; i++)
                {
                    _SendToServer.SucceededList.Add(false);
                }
            _MoveCursor.CollideDeadline = false;
                //Invoke(nameof(CursorOff), 0.3f);
                //Invoke(nameof(CursorOn), 0.4f);
                //Invoke(nameof(CursorOff), 0.5f);
                //Invoke(nameof(CursorOn), 0.6f);
                //Invoke(nameof(CursorOff), 0.7f);
                //Invoke(nameof(CursorOn), 0.8f);
            }
            else
            {
                OneResult.text = "Succeeded";
                int j = _SendToServer.TrialList.Count - _SendToServer.SucceededList.Count;
                for (int i = 0; i < j; i++)
                {
                    _SendToServer.SucceededList.Add(true);
                }
            }
        }


        if (_MoveTarget.isTracing)
        {
            if (_MoveTarget.RestTime % 5 < AppearLine - 1 && !_MoveTarget.isFinishied)
            {
                if (!isSettingline)
                {
                    setline(Ignitenumbers[IgniteTime]);
                    IgniteTime += 1;
                    isSettingline = true;
                }
                else
                {
                    minusColor();
                    //setCollider();
                }
                _SendToServer.TrialList.Add(IgniteTime - 1);
                _SendToServer.RestTimeList.Add(_MoveTarget.RestTime % 4);
                _SendToServer.LeftInputList.Add((Input.GetKey(KeyCode.W)) ? 1 : ((Input.GetKey(KeyCode.S)) ? -1 : 0));
                _SendToServer.RightInputList.Add((Input.GetKey(KeyCode.UpArrow)) ? 1 : ((Input.GetKey(KeyCode.DownArrow)) ? -1 : 0));
                _SendToServer.LeftPosList.Add(LeftCursor.transform.position);
                _SendToServer.RightPosList.Add(RightCursor.transform.position);
                _SendToServer.TargetPosList.Add(Cursor.transform.position);
                _SendToServer.LineNumList.Add(Ignitenumbers[IgniteTime - 1]);
                _SendToServer.ErrorNumList.Add(collidetime);

            }
            else if (_MoveTarget.RestTime % 5 > 4f && _MoveTarget.RestTime < 97 && isSettingline)
            {
                _MoveTarget.isTracing = false;
                setCollider();
                Ignition();
                isSettingline = false;
                isSettingTriger = true;
                isResting = true;
            }

        }

        if (_MoveTarget.isFinishied)
        {
            _MoveTarget.isFinishied = false;
            Ignition();
            isSettingline = false;
            setCollider();
            isSettingTriger = true;
            Invoke(nameof(ResetMaterial),0.2f);
            Invoke(nameof(UpdateUI), 0.4f);
        }

        if (isResting)
        {
            nowresttime += Time.fixedDeltaTime;
            if(nowresttime > 0.2f && !beappearui)
            {
                beappearui = true;
                whiteUi.SetActive(true);
                redUi.SetActive(true);
                ResetMaterial();
            }
            else if (nowresttime > 0.2f + showwhitetime && !befadewhiteui)
            {
                befadewhiteui = true;
                whiteUi.SetActive(false);
            }
            else if (nowresttime > 0.2f + resttime && !befaderedui)
            {
                befaderedui = true;
                Anten();
                redUi.SetActive(false);
            }
            else if (nowresttime > 1.2f + resttime)
            {
                RestartTracing();
                isResting = false;
                beappearui = false;
                befadewhiteui = false;
                befaderedui = false;
                nowresttime = 0;
            }
        }
    }

    void UpdateUI()
    {
        _collisionUI.text = "Success : " + (20 - collidetime).ToString() + "/20";
        _SendToServer.TrialList.Add(10);
        _SendToServer.RestTimeList.Add(0);
        _SendToServer.LeftInputList.Add(0);
        _SendToServer.RightInputList.Add(0);
        _SendToServer.LeftPosList.Add(Vector2.zero);
        _SendToServer.RightPosList.Add(Vector2.zero);
        _SendToServer.TargetPosList.Add(Vector2.zero);
        _SendToServer.LineNumList.Add(100);
        _SendToServer.ErrorNumList.Add(collidetime);
        _SendToServer.SucceededList.Add(false);
        _SendToServer.WritingToServer();
    }
    void SpawnChild()
    {
        for (int i = 0; i < Number_updown; i++)
        {
            Vector3 _uppos = new Vector3(minRange.x + (maxRange.x - minRange.x) * i / Number_updown, maxRange.y, 0);
            GameObject _DeadlinePoint = Instantiate(DeadlinePoint);
            _DeadlinePoint.transform.position = _uppos;
            LineRenderer _lineRenderer = _DeadlinePoint.AddComponent<LineRenderer>();
            PolygonCollider2D _polygonCollider2D = _DeadlinePoint.AddComponent<PolygonCollider2D>();
            _polygonCollider2D.isTrigger = true;
            Uppercollider.Add(_polygonCollider2D);
            _polygonCollider2D.points = _upperline1;
            _polygonCollider2D.enabled = false;
            DeadlineUpper.Add(_DeadlinePoint);
            UpperLine.Add(_lineRenderer);
            _DeadlinePoint.transform.parent = this.transform;
            _lineRenderer.material = red;
            _lineRenderer.enabled = false;

            Vector3 _lowpos = new Vector3(minRange.x + (maxRange.x - minRange.x) * i / Number_updown, minRange.y, 0);
            GameObject _DeadlinePoint2 = Instantiate(DeadlinePoint);
            _DeadlinePoint2.transform.position = _lowpos;
            LineRenderer _lineRenderer2 = _DeadlinePoint2.AddComponent<LineRenderer>();
            PolygonCollider2D _polygonCollider2D2 = _DeadlinePoint2.AddComponent<PolygonCollider2D>();
            _polygonCollider2D2.isTrigger = true;
            Lowercollider.Add(_polygonCollider2D2);
            _polygonCollider2D2.points = _upperline1;
            _polygonCollider2D2.enabled = false;
            DeadlineLower.Add(_DeadlinePoint2);
            LowerLine.Add(_lineRenderer2);
            _DeadlinePoint2.transform.parent = this.transform;
            _lineRenderer2.material = red;
            _lineRenderer2.enabled = false;
        }
        for (int i = 0; i < Number_rightleft; i++)
        {
            Vector3 _leftpos = new Vector3(minRange.x, minRange.y + (maxRange.y - minRange.y) * i / Number_rightleft, 0);
            GameObject _DeadlinePoint = Instantiate(DeadlinePoint);
            _DeadlinePoint.transform.position = _leftpos;
            LineRenderer _lineRenderer = _DeadlinePoint.AddComponent<LineRenderer>();
            PolygonCollider2D _polygonCollider2D = _DeadlinePoint.AddComponent<PolygonCollider2D>();
            _polygonCollider2D.isTrigger = true;
            Leftcollider.Add(_polygonCollider2D);
            _polygonCollider2D.enabled = false;
            _polygonCollider2D.points = _upperline1;
            DeadlineLeft.Add(_DeadlinePoint);
            LeftLine.Add(_lineRenderer);
            _DeadlinePoint.transform.parent = this.transform;
            _lineRenderer.material = red;
            _lineRenderer.enabled = false;

            Vector3 _rightpos = new Vector3(maxRange.x, minRange.y + (maxRange.y - minRange.y) * i / Number_rightleft, 0);
            GameObject _DeadlinePoint2 = Instantiate(DeadlinePoint);
            _DeadlinePoint2.transform.position = _rightpos;
            LineRenderer _lineRenderer2 = _DeadlinePoint2.AddComponent<LineRenderer>();
            PolygonCollider2D _polygonCollider2D2 = _DeadlinePoint2.AddComponent<PolygonCollider2D>();
            _polygonCollider2D2.isTrigger = true;
            Rightcollider.Add(_polygonCollider2D2);
            _polygonCollider2D2.points = _upperline1;
            _polygonCollider2D2.enabled = false;
            DeadlineRight.Add(_DeadlinePoint2);
            RightLine.Add(_lineRenderer2);
            _DeadlinePoint2.transform.parent = this.transform;
            _lineRenderer2.material = red;
            _lineRenderer2.enabled = false;
        }

    }
    void fadeline()
    {
        //foreach (LineRenderer _lineRenderer in UpperLine)
        //{
        //    _lineRenderer.enabled = false;
        //}
        //foreach (LineRenderer _lineRenderer in LowerLine)
        //{
        //    _lineRenderer.enabled = false;
        //}
        //foreach (LineRenderer _lineRenderer in RightLine)
        //{
        //    _lineRenderer.enabled = false;
        //}
        //foreach (LineRenderer _lineRenderer in LeftLine)
        //{
        //    _lineRenderer.enabled = false;
        //}

        UpperLine[_upperpoint1].enabled = false;
        UpperLine[_upperpoint2].enabled = false;
        UpperLine[_upperpoint3].enabled = false;
        UpperLine[_upperpoint4].enabled = false;
        UpperLine[_upperpoint5].enabled = false;
        UpperLine[_upperpoint6].enabled = false;
        LowerLine[_upperpoint7].enabled = false;
        LowerLine[_upperpoint8].enabled = false;


        RightLine[_rightpoint1].enabled = false;
        RightLine[_rightpoint2].enabled = false;
        RightLine[_rightpoint3].enabled = false;
        RightLine[_rightpoint4].enabled = false;
        LeftLine[_rightpoint5].enabled = false;
        LeftLine[_rightpoint6].enabled = false;
    }
    void setline(int i)
    {
        //_upperpoint1 = Random.Range(0, (int)Number_updown / 2);
        //_upperpoint2 = Random.Range(0, (int)Number_updown / 2);
        //_upperpoint3 = Random.Range((int)Number_updown / 2, Number_updown);
        //_upperpoint4 = Random.Range((int)Number_updown / 2, Number_updown);
        //_upperpoint5 = Mathf.FloorToInt((Cursor.position.x - minRange.x) / (maxRange.x - minRange.x) * Number_updown);

        //_lowerpoint1 = Random.Range(0, (int)Number_updown / 2);
        //_lowerpoint2 = Random.Range(0, (int)Number_updown / 2);
        //_lowerpoint3 = Random.Range((int)Number_updown / 2, Number_updown);
        //_lowerpoint4 = Random.Range((int)Number_updown / 2, Number_updown);
        //_lowerpoint5 = _upperpoint5;

        _upperpoint1 = DeadlineList2.upperpoints1[i];
        _upperpoint2 = DeadlineList2.upperpoints2[i];
        _upperpoint3 = DeadlineList2.upperpoints3[i];
        _upperpoint4 = DeadlineList2.upperpoints4[i];
        _upperpoint5 = DeadlineList2.upperpoints5[i];
        _upperpoint6 = DeadlineList2.upperpoints6[i];
        _upperpoint7 = DeadlineList2.upperpoints7[i];
        _upperpoint8 = DeadlineList2.upperpoints8[i];

        _lowerpoint1 = DeadlineList2.lowerpoints1[i];
        _lowerpoint2 = DeadlineList2.lowerpoints2[i];
        _lowerpoint3 = DeadlineList2.lowerpoints3[i];
        _lowerpoint4 = DeadlineList2.lowerpoints4[i];
        _lowerpoint5 = _upperpoint5;
        _lowerpoint6 = _upperpoint6;
        _lowerpoint7 = _upperpoint7;
        _lowerpoint8 = _upperpoint8;

        UpperLine[_upperpoint1].enabled = true;
        UpperLine[_upperpoint2].enabled = true;
        UpperLine[_upperpoint3].enabled = true;
        UpperLine[_upperpoint4].enabled = true;
        UpperLine[_upperpoint5].enabled = true;
        UpperLine[_upperpoint6].enabled = true;
        LowerLine[_upperpoint7].enabled = true;
        LowerLine[_upperpoint8].enabled = true;

        UpperLine[_upperpoint1].SetPosition(0, DeadlineUpper[_upperpoint1].transform.position);
        UpperLine[_upperpoint1].SetPosition(1, DeadlineLower[_lowerpoint1].transform.position);
        UpperLine[_upperpoint2].SetPosition(0, DeadlineUpper[_upperpoint2].transform.position);
        UpperLine[_upperpoint2].SetPosition(1, DeadlineLower[_lowerpoint3].transform.position);
        UpperLine[_upperpoint3].SetPosition(0, DeadlineUpper[_upperpoint3].transform.position);
        UpperLine[_upperpoint3].SetPosition(1, DeadlineLower[_lowerpoint2].transform.position);
        UpperLine[_upperpoint4].SetPosition(0, DeadlineUpper[_upperpoint4].transform.position);
        UpperLine[_upperpoint4].SetPosition(1, DeadlineLower[_lowerpoint4].transform.position);
        UpperLine[_upperpoint5].SetPosition(0, DeadlineUpper[_upperpoint5].transform.position);
        UpperLine[_upperpoint5].SetPosition(1, DeadlineLower[_lowerpoint5].transform.position);
        UpperLine[_upperpoint6].SetPosition(0, DeadlineUpper[_upperpoint6].transform.position);
        UpperLine[_upperpoint6].SetPosition(1, DeadlineLower[_lowerpoint6].transform.position);
        LowerLine[_upperpoint7].SetPosition(0, DeadlineUpper[_upperpoint7].transform.position);
        LowerLine[_upperpoint7].SetPosition(1, DeadlineLower[_lowerpoint7].transform.position);
        LowerLine[_upperpoint8].SetPosition(0, DeadlineUpper[_upperpoint8].transform.position);
        LowerLine[_upperpoint8].SetPosition(1, DeadlineLower[_lowerpoint8].transform.position);


        _rightpoint1 = DeadlineList2.rightpoints1[i];
        _rightpoint2 = DeadlineList2.rightpoints2[i];
        _rightpoint3 = DeadlineList2.rightpoints3[i];
        _rightpoint4 = DeadlineList2.rightpoints4[i];
        _rightpoint5 = DeadlineList2.rightpoints5[i];
        _rightpoint6 = DeadlineList2.rightpoints6[i];

        _leftpoint1 = DeadlineList2.leftpoints1[i];
        _leftpoint2 = DeadlineList2.leftpoints2[i];
        _leftpoint3 = DeadlineList2.leftpoints3[i];
        _leftpoint4 = DeadlineList2.leftpoints4[i];
        _leftpoint5 = _rightpoint5;
        _leftpoint6 = _rightpoint6;

        RightLine[_rightpoint1].enabled = true;
        RightLine[_rightpoint2].enabled = true;
        RightLine[_rightpoint3].enabled = true;
        RightLine[_rightpoint4].enabled = true;
        LeftLine[_rightpoint5].enabled = true;
        LeftLine[_rightpoint6].enabled = true;

        RightLine[_rightpoint1].SetPosition(0, DeadlineRight[_rightpoint1].transform.position);
        RightLine[_rightpoint1].SetPosition(1, DeadlineLeft[_leftpoint1].transform.position);
        RightLine[_rightpoint2].SetPosition(0, DeadlineRight[_rightpoint2].transform.position);
        RightLine[_rightpoint2].SetPosition(1, DeadlineLeft[_leftpoint3].transform.position);
        RightLine[_rightpoint3].SetPosition(0, DeadlineRight[_rightpoint3].transform.position);
        RightLine[_rightpoint3].SetPosition(1, DeadlineLeft[_leftpoint2].transform.position);
        RightLine[_rightpoint4].SetPosition(0, DeadlineRight[_rightpoint4].transform.position);
        RightLine[_rightpoint4].SetPosition(1, DeadlineLeft[_leftpoint4].transform.position);
        LeftLine[_rightpoint5].SetPosition(0, DeadlineRight[_rightpoint5].transform.position);
        LeftLine[_rightpoint5].SetPosition(1, DeadlineLeft[_leftpoint5].transform.position);
        LeftLine[_rightpoint6].SetPosition(0, DeadlineRight[_rightpoint6].transform.position);
        LeftLine[_rightpoint6].SetPosition(1, DeadlineLeft[_leftpoint6].transform.position);
        CanMoveBall = true;
    }
    void setCollider()
    {
        _upperline1 = new Vector2[]
        {
            (new Vector2(-0.5f,0)),
            (new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint1].transform.position - (Vector2)DeadlineUpper[_upperpoint1].transform.position  + new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint1].transform.position - (Vector2)DeadlineUpper[_upperpoint1].transform.position  - new Vector2(0.5f,0)),
        };
        _upperline2 = new Vector2[]
{
            ( - new Vector2(0.5f,0)),
            (new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint3].transform.position -(Vector2)DeadlineUpper[_upperpoint2].transform.position + new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint3].transform.position- (Vector2)DeadlineUpper[_upperpoint2].transform.position - new Vector2(0.5f,0)),
};
        _upperline3 = new Vector2[]
{
            ( - new Vector2(0.5f,0)),
            (new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint2].transform.position - (Vector2)DeadlineUpper[_upperpoint3].transform.position + new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint2].transform.position- (Vector2)DeadlineUpper[_upperpoint3].transform.position - new Vector2(0.5f,0)),
};
        _upperline4 = new Vector2[]
{
            ( - new Vector2(0.5f,0)),
            (new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint4].transform.position - (Vector2)DeadlineUpper[_upperpoint4].transform.position + new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint4].transform.position - (Vector2)DeadlineUpper[_upperpoint4].transform.position - new Vector2(0.5f,0)),
};
        _upperline5 = new Vector2[]
{
            ( - new Vector2(0.5f,0)),
            (new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint5].transform.position - (Vector2)DeadlineUpper[_upperpoint5].transform.position + new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint5].transform.position - (Vector2)DeadlineUpper[_upperpoint5].transform.position - new Vector2(0.5f,0)),
};
        _upperline6 = new Vector2[]
{
            ( - new Vector2(0.5f,0)),
            (new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint6].transform.position - (Vector2)DeadlineUpper[_upperpoint6].transform.position + new Vector2(0.5f,0)),
            ((Vector2)DeadlineLower[_lowerpoint6].transform.position - (Vector2)DeadlineUpper[_upperpoint6].transform.position - new Vector2(0.5f,0)),
};
        _upperline7 = new Vector2[]
{
            ( - new Vector2(0.5f,0)),
            (new Vector2(0.5f,0)),
            (-(Vector2)DeadlineLower[_lowerpoint7].transform.position + (Vector2)DeadlineUpper[_upperpoint7].transform.position + new Vector2(0.5f,0)),
            (-(Vector2)DeadlineLower[_lowerpoint7].transform.position + (Vector2)DeadlineUpper[_upperpoint7].transform.position - new Vector2(0.5f,0)),
};
        _upperline8 = new Vector2[]
{
            ( - new Vector2(0.5f,0)),
            (new Vector2(0.5f,0)),
            (-(Vector2)DeadlineLower[_lowerpoint8].transform.position + (Vector2)DeadlineUpper[_upperpoint8].transform.position + new Vector2(0.5f,0)),
            (-(Vector2)DeadlineLower[_lowerpoint8].transform.position + (Vector2)DeadlineUpper[_upperpoint8].transform.position - new Vector2(0.5f,0)),
};


        Uppercollider[_upperpoint1].enabled = true;
        Uppercollider[_upperpoint2].enabled = true;
        Uppercollider[_upperpoint3].enabled = true;
        Uppercollider[_upperpoint4].enabled = true;
        Uppercollider[_upperpoint5].enabled = true;
        Uppercollider[_upperpoint6].enabled = true;
        Lowercollider[_upperpoint7].enabled = true;
        Lowercollider[_upperpoint8].enabled = true;

        Uppercollider[_upperpoint1].points = _upperline1;
        Uppercollider[_upperpoint2].points = _upperline2;
        Uppercollider[_upperpoint3].points = _upperline3;
        Uppercollider[_upperpoint4].points = _upperline4;
        Uppercollider[_upperpoint5].points = _upperline5;
        Uppercollider[_upperpoint6].points = _upperline6;
        Lowercollider[_upperpoint7].points = _upperline7;
        Lowercollider[_upperpoint8].points = _upperline8;

        _rightline1 = new Vector2[]
{
            (- new Vector2(0,0.5f)),
            ( new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint1].transform.position - (Vector2)DeadlineRight[_rightpoint1].transform.position  + new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint1].transform.position - (Vector2)DeadlineRight[_rightpoint1].transform.position  - new Vector2(0,0.5f)),
};
        _rightline2 = new Vector2[]
{
            (- new Vector2(0,0.5f)),
            ( new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint3].transform.position - (Vector2)DeadlineRight[_rightpoint2].transform.position + new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint3].transform.position - (Vector2)DeadlineRight[_rightpoint2].transform.position  - new Vector2(0,0.5f)),
};
        _rightline3 = new Vector2[]
{
            (- new Vector2(0,0.5f)),
            ( new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint2].transform.position - (Vector2)DeadlineRight[_rightpoint3].transform.position  + new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint2].transform.position - (Vector2)DeadlineRight[_rightpoint3].transform.position  - new Vector2(0,0.5f)),
};
        _rightline4 = new Vector2[]
{
            ( - new Vector2(0,0.5f)),
            (new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint4].transform.position - (Vector2)DeadlineRight[_rightpoint4].transform.position + new Vector2(0,0.5f)),
            ((Vector2)DeadlineLeft[_leftpoint4].transform.position - (Vector2)DeadlineRight[_rightpoint4].transform.position - new Vector2(0,0.5f)),
};

        _rightline5 = new Vector2[]
{
            ( - new Vector2(0,0.5f)),
            (new Vector2(0,0.5f)),
            (-(Vector2)DeadlineLeft[_leftpoint5].transform.position + (Vector2)DeadlineRight[_rightpoint5].transform.position + new Vector2(0,0.5f)),
            (-(Vector2)DeadlineLeft[_leftpoint5].transform.position + (Vector2)DeadlineRight[_rightpoint5].transform.position - new Vector2(0,0.5f)),
};

        _rightline6 = new Vector2[]
{
            ( - new Vector2(0,0.5f)),
            (new Vector2(0,0.5f)),
            (-(Vector2)DeadlineLeft[_leftpoint6].transform.position + (Vector2)DeadlineRight[_rightpoint6].transform.position + new Vector2(0,0.5f)),
            (-(Vector2)DeadlineLeft[_leftpoint6].transform.position + (Vector2)DeadlineRight[_rightpoint6].transform.position - new Vector2(0,0.5f)),
};

        Rightcollider[_rightpoint1].points = _rightline1;
        Rightcollider[_rightpoint2].points = _rightline2;
        Rightcollider[_rightpoint3].points = _rightline3;
        Rightcollider[_rightpoint4].points = _rightline4;
        Leftcollider[_rightpoint5].points = _rightline5;
        Leftcollider[_rightpoint6].points = _rightline6;


        Rightcollider[_rightpoint1].enabled = true;
        Rightcollider[_rightpoint2].enabled = true;
        Rightcollider[_rightpoint3].enabled = true;
        Rightcollider[_rightpoint4].enabled = true;
        Leftcollider[_rightpoint5].enabled = true;
        Leftcollider[_rightpoint6].enabled = true;


    }
    void ResetMaterial()
    {
        fadeline();
        red.color = new Color(255, 0, 0, defaultcolor);
        UpperLine[_upperpoint1].material = red;
        UpperLine[_upperpoint2].material = red;
        UpperLine[_upperpoint3].material = red;
        UpperLine[_upperpoint4].material = red;
        UpperLine[_upperpoint5].material = red;
        UpperLine[_upperpoint6].material = red;
        LowerLine[_upperpoint7].material = red;
        LowerLine[_upperpoint8].material = red;
        RightLine[_rightpoint1].material = red;
        RightLine[_rightpoint2].material = red;
        RightLine[_rightpoint3].material = red;
        RightLine[_rightpoint4].material = red;
        LeftLine[_rightpoint5].material = red;
        LeftLine[_rightpoint6].material = red;
        ResetPos();
    }
    void fadecollider()
    {
        Uppercollider[_upperpoint1].enabled = false;
        Uppercollider[_upperpoint2].enabled = false;
        Uppercollider[_upperpoint3].enabled = false;
        Uppercollider[_upperpoint4].enabled = false;
        Uppercollider[_upperpoint5].enabled = false;
        Uppercollider[_upperpoint6].enabled = false;
        Lowercollider[_upperpoint7].enabled = false;
        Lowercollider[_upperpoint8].enabled = false;

        Rightcollider[_rightpoint1].enabled = false;
        Rightcollider[_rightpoint2].enabled = false;
        Rightcollider[_rightpoint3].enabled = false;
        Rightcollider[_rightpoint4].enabled = false;
        Leftcollider[_rightpoint5].enabled = false;
        Leftcollider[_rightpoint6].enabled = false;
    }
    public void minusColor()
    {
        float nowcolor = red.color.a;
        red.color = new Color(255, 0, 0, nowcolor - (defaultcolor - 0.01f) / AppearLine * Time.deltaTime);
    }
    public void Ignition()
    {
        UpperLine[_upperpoint1].material = white;
        UpperLine[_upperpoint2].material = white;
        UpperLine[_upperpoint3].material = white;
        UpperLine[_upperpoint4].material = white;
        UpperLine[_upperpoint5].material = white;
        UpperLine[_upperpoint6].material = white;
        LowerLine[_upperpoint7].material = white;
        LowerLine[_upperpoint8].material = white;
        RightLine[_rightpoint1].material = white;
        RightLine[_rightpoint2].material = white;
        RightLine[_rightpoint3].material = white;
        RightLine[_rightpoint4].material = white;
        LeftLine[_rightpoint5].material = white;
        LeftLine[_rightpoint6].material = white;

    }
    void CursorOn()
    {
        cursorcolor.color = new Color(255, 0, 0, 1);

    }
    void CursorOff()
    {
        cursorcolor.color = new Color(255, 0, 0, 0);
    }
    void RopeInitialize()
    {
        foreach (Transform child in RopeParent.transform)
        {
            RopeChildrenTransform.Add(child);
            Vector3 pos = child.position;
            Quaternion rot = child.rotation;
            RopeChildrenfirstPosition.Add(pos);
            RopeChildrenfirstQuaternion.Add(rot);
        }
    }
    private void Initialize()
    {
        firstCursorPos = Cursor.transform.position;
        firstCursorRot = Cursor.transform.rotation;
        firstRightCursorPos = RightCursor.transform.position;
        firstRightCursorRot = RightCursor.transform.rotation;
        firstLeftCursorPos = LeftCursor.transform.position;
        firstLeftCursorRot = LeftCursor.transform.rotation;
    }
    private void ResetPos()
    {
        Cursor.transform.position = firstCursorPos;
        Cursor.transform.rotation = firstCursorRot;
        RightCursor.transform.position = firstRightCursorPos;
        RightCursor.transform.rotation = firstRightCursorRot;
        LeftCursor.transform.position = firstLeftCursorPos;
        LeftCursor.transform.rotation = firstLeftCursorRot;
        for (int i = 0; i < RopeChildrenTransform.Count; i++)
        {
            RopeChildrenTransform[i].position = RopeChildrenfirstPosition[i];
            RopeChildrenTransform[i].rotation = RopeChildrenfirstQuaternion[i];
        }
        _cursorRigidbody.velocity = new Vector2(0,0);
    }
    void Anten()
    {
        CanMoveBall = false;
        image.color = new Color(0, 0, 0, 1f);
        isAnten = true;
    }
    void AddAnten()
    {
        float a = image.color.a;
        image.color = new Color(0, 0, 0, 0);
    }
    void RestartTracing()
    {
        _MoveTarget.isTracing = true;
        isAnten = false;
        image.color = new Color(0, 0, 0, 0f);
    }
}
