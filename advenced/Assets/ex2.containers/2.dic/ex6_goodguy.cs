using UnityEngine;
using System.Collections;
using System;

public class ex6_goodguy : IComparable<ex6_goodguy>
{
	public string m_strName;
	public int m_nPower;

	public ex6_goodguy(string newName, int newPower)
	{
		m_strName = newName;
		m_nPower = newPower;
	}


	public int CompareTo(ex6_goodguy other)
	{
		if(other == null)
		{
			return 1;
		}

		//Return the difference in power.
		return m_nPower - other.m_nPower;
	}



}
