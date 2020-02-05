using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seconds
{
	[CreateAssetMenu(fileName = "Category", menuName = "Seconds/Category", order = 0)]
	public class Category : ScriptableObject
	{
		[SerializeField]
		public List<string> topics = new List<string>();
	}
}