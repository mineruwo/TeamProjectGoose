using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GardenerJob : MonoBehaviour
{
    public Job gardenerToDo;

    public bool isFinished = false;

    public Transform objectsPos;

    public List<GameObject> destinations = new List<GameObject>();

    //���������� ���� �� �� -> if ������ item ����� �� chase
    public void DoNothing()
    {
        //�� ��� �״�� Idle animation
    }

    public void Watering()
    {
        Vector3 wateringCanPos = objectsPos.position;
        //�긦 ��� ������

        //���Ѹ��� �ִ� ��ҷ� ��
        //���Ѹ��� ��� �� �ִ� ������ ��
        //�� ��
        //���Ѹ��� ���� ��ҿ�

        DoNothing();
    }

    public void CaringPlants()
    {
        Vector3 shovelPos = objectsPos.position;
        //���� ���� �ִ� �� ������ ��
        //if ���ڸ��� ������ ?? �ִϸ��̼�
        //�ٸ� �۾�
        //������ �� ��� �����ִ� ȭ�ܿ� ��
        //����
        //�� �ٽ� ���� �ڸ���

        DoNothing();
    }

    public void CarryingVase()
    {
        Vector3 vasePos = objectsPos.position;
        //�ٵ� ��� �ѹ� �ű�� ���ڸ��� ����������ϴϱ� . . .. ������Ʈ����...??
    }
}
