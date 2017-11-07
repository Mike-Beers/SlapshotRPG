using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkaterStats : MonoBehaviour {

//variables
	public int speed;
	public int shooting;
	public int passing;
	public int stickSkills;
	public int physical;
	public int defense;
	public int faceoff;

//Methods
	public void IncreaseStat (int statIncrease, string statType)
	{
		statType += statIncrease;
	}
	public void SetStat(int statValue, string statType)
	{
		statType = statValue.ToString();
	}
}
