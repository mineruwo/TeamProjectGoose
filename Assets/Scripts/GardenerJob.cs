using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GardenerJob : MonoBehaviour
{
    public Job gardenerToDo;


    public List<GameObject> destinations = new List<GameObject>();

    private void Start()
    {

    }
    //���������� ���� �� �� -> if ������ item ����� �� chase
    public void DoNothing()
    {
        //�� ��� �״�� Idle animation
    }

    public void Watering()
    {
        //�긦 ��� ������

        //���Ѹ��� �ִ� ��ҷ� ��
        //���Ѹ��� ��� �� �ִ� ������ ��
        //�� ��
        //���Ѹ��� ���� ��ҿ�

        DoNothing();
    }

    public void CaringPlants()
    {
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

    }
}
