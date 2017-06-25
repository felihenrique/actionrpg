using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ItemStack<T> where T : Item
	{
		private int size;
		private int maxSize;
		private List<T> itens;
		public int Size
		{
			get { return size; }
			set { size = Mathf.Clamp(value, 0, maxSize); }
		}
		public int MaxSize
		{
			get { return maxSize; }
			set { maxSize = value; size = Mathf.Clamp(size, 0, maxSize); }
		}

		public ItemStack()
		{
		}
	}
}
