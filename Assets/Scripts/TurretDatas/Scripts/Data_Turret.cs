using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turrets
{
    Minigun,        //미니건터렛(공격속도가 점점빨라지지만 공격력이 낮음)
    Boom,           //폭탄터렛(공격속도가 느리고 착탄딜레이가 있지만 강한 범위공격)
    Lightning,      //번개터렛(공격속도가 매우느리지만 사정거리가 매우 넓으며 범위에 즉사급 공격)
};
[CreateAssetMenu(fileName = "TurretData", menuName = "Turret/TurretData")]//파일네임 메뉴네임
public class Data_Turret : ScriptableObject
{
    public Turrets Kinds;               //터렛의 종류
    public Sprite Icon;                 //터렛의 아이콘
    public Turret Prefab;               //터렛의 프리팹
    public string Description;          //터렛에 대한 설명
    public string UpgradeDescription;   //터렛 업그레이드에 대한 설명
    public int Level;                   //터렛의 레벨
    public int Cost;                    //비용
    public int Sell;                    //팔때의 비용
    public float Damage;                //터렛의 데미지
    public float Range;                 //사정거리
    public float FireRate;              //공격속도
}
