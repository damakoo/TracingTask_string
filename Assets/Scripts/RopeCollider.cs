using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollider : MonoBehaviour
{
    EdgeCollider2D _edgeCollider2D;
    [SerializeField] GameObject Ropeparent;
    List<Transform> RopeChildrenTransform = new List<Transform>();
    List<Vector2> RopeChildrenPos = new List<Vector2>();
    int childCount;

    // Start is called before the first frame update
    void Start()
    {
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
        childCount = Ropeparent.transform.childCount;

        // 子オブジェクトを順に取得する
        for (int i = 0; i < childCount; i++)
        {
            RopeChildrenTransform.Add(Ropeparent.transform.GetChild(i));
            RopeChildrenPos.Add(RopeChildrenTransform[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < childCount; i++)
        {
            RopeChildrenPos[i] = RopeChildrenTransform[i].position;
        }

        _edgeCollider2D.points = RopeChildrenPos.ToArray();
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
    }
}
