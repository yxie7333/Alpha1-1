using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pice : MonoBehaviour
{
    public int index;
    public Vector3 startpos;
    private Vector3 offset;
    //private Vector3 targetpos;
    //private float threshold = 0.1f; // 根据需要进行调整
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {

    }
    public bool followEnable = true;//能否跟随鼠标
    public bool hasPut;//
    /// <summary>
    /// 开始拖拽
    /// </summary>
    private void OnMouseDown()
    {
        if (hasPut == false)
        {
            // 计算鼠标点击点和碎片中心之间的偏移
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            followEnable = true;
        }

    }
    private void OnMouseDrag()
    {
        Vector3 mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//鼠标在3D世界的位置
        mouspos.z = 0;
        // 设置碎片的位置为鼠标点击点位置加上偏移
        transform.position = mouspos + offset;
    }
    private void OnMouseUp()
    {
       // followEnable = false;

        // 计算碎片的位置修正
        //float distance = Vector3.Distance(transform.position, targetpos);

        //if (distance > threshold)
        //{
            // 如果距离大于一个阈值，将碎片移回预定位置
            //transform.position = targetpos;
        //}

            if (currentGrid >= 0)
            {
                if (currentGrid == index)
                {
                    hasPut = true;
                transform.position = triggerGrid.transform.position;
                triggerGrid.OnPutRight();
                
                }
                else
                {
                    transform.position = startpos;
                }
            }
            else
            {
                transform.position = startpos;
            }
        
    }

    private int currentGrid = -1;
    private Grid triggerGrid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grid")
        {
            Grid grid = collision.GetComponent<Grid>();
            if (!grid.hasPut)
            {
                triggerGrid = grid;
                currentGrid = int.Parse(collision.name);
                //---------------如果掠过就放置 打开下面的
                if (currentGrid == index)
                {
                hasPut = true;
                ////格子下icon显示
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(gameObject);
                ////换位
                transform.position = collision.transform.position;
                followEnable = false;
                //-------------------
                 }
            }
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerGrid != null && collision.gameObject == triggerGrid.gameObject)
        {
            triggerGrid = null;
            currentGrid = -1;
        }


    }
}
