using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PointSetting_const : MonoBehaviour
{
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
    private bool isSettingTriger2 = false;
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

    public int _upperpoint1;
    public int _upperpoint2;
    public int _upperpoint3;
    public int _upperpoint4;
    public int _upperpoint5;
    public int _upperpoint6;

    public int _lowerpoint1;
    public int _lowerpoint2;
    public int _lowerpoint3;
    public int _lowerpoint4;
    public int _lowerpoint5;
    public int _lowerpoint6;

    public int _rightpoint1;
    public int _rightpoint2;
    public int _rightpoint3;
    public int _rightpoint4;

    public int _leftpoint1;
    public int _leftpoint2;
    public int _leftpoint3;
    public int _leftpoint4;

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
        RopeInitialize();
        Initialize();
        _collisionUI.text = "";
        SpawnChild();
        for (int i = 0; i < 10; i++)
        {
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
        if (isAnten) AddAnten();
        if (isSettingTriger2)
        {
            isSettingTriger = false;
            isSettingTriger2 = false;
            fadecollider();
            if (_MoveCursor.CollideDeadline)
            {
                collidetime += 1;
                _MoveCursor.CollideDeadline = false;
                Invoke(nameof(CursorOff), 0.3f);
                Invoke(nameof(CursorOn), 0.4f);
                Invoke(nameof(CursorOff), 0.5f);
                Invoke(nameof(CursorOn), 0.6f);
                Invoke(nameof(CursorOff), 0.7f);
                Invoke(nameof(CursorOn), 0.8f);
            }
        }

        if (isSettingTriger)
        {
            isSettingTriger2 = true;
        }

        if (_MoveTarget.isTracing)
        {
            if (_MoveTarget.RestTime % 4 < AppearLine - 1)
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
            }
            else if (_MoveTarget.RestTime % 4 > 3f && isSettingline)
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
            Invoke(nameof(UpdateUI),0.25f);
        }

        if (Input.GetKeyDown(KeyCode.K)) setline(0);
        if (Input.GetKeyDown(KeyCode.L)) fadeline();
    }
    void UpdateUI()
    {
        _collisionUI.text = collidetime.ToString();
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


        RightLine[_rightpoint1].enabled = false;
        RightLine[_rightpoint2].enabled = false;
        RightLine[_rightpoint3].enabled = false;
        RightLine[_rightpoint4].enabled = false;
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

        _upperpoint1 = DeadlineList.upperpoints1[i];
        _upperpoint2 = DeadlineList.upperpoints2[i];
        _upperpoint3 = DeadlineList.upperpoints3[i];
        _upperpoint4 = DeadlineList.upperpoints4[i];
        _upperpoint5 = DeadlineList.upperpoints5[i];
        _upperpoint6 = DeadlineList.upperpoints6[i];

        _lowerpoint1 = DeadlineList.lowerpoints1[i];
        _lowerpoint2 = DeadlineList.lowerpoints2[i];
        _lowerpoint3 = DeadlineList.lowerpoints3[i];
        _lowerpoint4 = DeadlineList.lowerpoints4[i];
        _lowerpoint5 = _upperpoint5;
        _lowerpoint6 = _upperpoint6;

        UpperLine[_upperpoint1].enabled = true;
        UpperLine[_upperpoint2].enabled = true;
        UpperLine[_upperpoint3].enabled = true;
        UpperLine[_upperpoint4].enabled = true;
        UpperLine[_upperpoint5].enabled = true;
        UpperLine[_upperpoint6].enabled = true;

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


        _rightpoint1 = DeadlineList.rightpoints1[i];
        _rightpoint2 = DeadlineList.rightpoints2[i];
        _rightpoint3 = DeadlineList.rightpoints3[i];
        _rightpoint4 = DeadlineList.rightpoints4[i];

        _leftpoint1 = DeadlineList.leftpoints1[i];
        _leftpoint2 = DeadlineList.leftpoints2[i];
        _leftpoint3 = DeadlineList.leftpoints3[i];
        _leftpoint4 = DeadlineList.leftpoints4[i];

        RightLine[_rightpoint1].enabled = true;
        RightLine[_rightpoint2].enabled = true;
        RightLine[_rightpoint3].enabled = true;
        RightLine[_rightpoint4].enabled = true;

        RightLine[_rightpoint1].SetPosition(0, DeadlineRight[_rightpoint1].transform.position);
        RightLine[_rightpoint1].SetPosition(1, DeadlineLeft[_leftpoint1].transform.position);
        RightLine[_rightpoint2].SetPosition(0, DeadlineRight[_rightpoint2].transform.position);
        RightLine[_rightpoint2].SetPosition(1, DeadlineLeft[_leftpoint3].transform.position);
        RightLine[_rightpoint3].SetPosition(0, DeadlineRight[_rightpoint3].transform.position);
        RightLine[_rightpoint3].SetPosition(1, DeadlineLeft[_leftpoint2].transform.position);
        RightLine[_rightpoint4].SetPosition(0, DeadlineRight[_rightpoint4].transform.position);
        RightLine[_rightpoint4].SetPosition(1, DeadlineLeft[_leftpoint4].transform.position);
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


        Uppercollider[_upperpoint1].enabled = true;
        Uppercollider[_upperpoint2].enabled = true;
        Uppercollider[_upperpoint3].enabled = true;
        Uppercollider[_upperpoint4].enabled = true;
        Uppercollider[_upperpoint5].enabled = true;
        Uppercollider[_upperpoint6].enabled = true;

        Uppercollider[_upperpoint1].points = _upperline1;
        Uppercollider[_upperpoint2].points = _upperline2;
        Uppercollider[_upperpoint3].points = _upperline3;
        Uppercollider[_upperpoint4].points = _upperline4;
        Uppercollider[_upperpoint5].points = _upperline5;
        Uppercollider[_upperpoint6].points = _upperline6;

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
            ((Vector2)DeadlineLeft[_leftpoint4].transform.position - (Vector2)DeadlineRight[_rightpoint4].transform.position   - new Vector2(0,0.5f)),
};

        Rightcollider[_rightpoint1].points = _rightline1;
        Rightcollider[_rightpoint2].points = _rightline2;
        Rightcollider[_rightpoint3].points = _rightline3;
        Rightcollider[_rightpoint4].points = _rightline4;


        Rightcollider[_rightpoint1].enabled = true;
        Rightcollider[_rightpoint2].enabled = true;
        Rightcollider[_rightpoint3].enabled = true;
        Rightcollider[_rightpoint4].enabled = true;

    }
    private void ResetMaterial()
    {
        fadeline();
        red.color = new Color(255, 0, 0, defaultcolor);
        UpperLine[_upperpoint1].material = red;
        UpperLine[_upperpoint2].material = red;
        UpperLine[_upperpoint3].material = red;
        UpperLine[_upperpoint4].material = red;
        UpperLine[_upperpoint5].material = red;
        UpperLine[_upperpoint6].material = red;
        RightLine[_rightpoint1].material = red;
        RightLine[_rightpoint2].material = red;
        RightLine[_rightpoint3].material = red;
        RightLine[_rightpoint4].material = red;
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

        Rightcollider[_rightpoint1].enabled = false;
        Rightcollider[_rightpoint2].enabled = false;
        Rightcollider[_rightpoint3].enabled = false;
        Rightcollider[_rightpoint4].enabled = false;
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
        RightLine[_rightpoint1].material = white;
        RightLine[_rightpoint2].material = white;
        RightLine[_rightpoint3].material = white;
        RightLine[_rightpoint4].material = white;
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
        image.color = new Color(0, 0, 0, 1f);
        isAnten = true;
    }
    void AddAnten()
    {
        float a = image.color.a;
        image.color = new Color(0, 0, 0, a - Time.deltaTime);
    }
    void RestartTracing()
    {
        _MoveTarget.isTracing = true;
        isAnten = false;
        image.color = new Color(0, 0, 0, 0f);
    }
}
