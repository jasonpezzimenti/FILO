using System.Collections;

namespace FILO
{
	public class FILO<T> : IEnumerable<T>
	{
		public T[] Items;

		/// <summary>
		/// Gets the number of items in the List.
		/// </summary>
		public int Count { get { return Items.Length; } }

		public enum ListPositions
		{
			First = 0,
			Last
		}

		public static ListPositions ListPosition { get; set; }

		public FILO(int capacity = 0)
		{
			Items = new T[capacity];
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			if(Items != null && Count >= 1)
			{
				foreach(T item in Items)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		private void ResizeArray()
		{
			T[] array = new T[Count + 1];

			for (int index = 0; index < Count; index++)
			{
				array[index] = Items[index];
			}

			Items = array;
		}

		public void Add(T item)
		{
			ResizeArray();
			Items[Count - 1] = item;
		}

		public void Remove()
		{
			Remove(Count - 1);
		}

		public void Remove(int index)
		{
			Items = Items.Where<T>((value, i) => i != index).ToArray();
		}

		public void Remove(ListPositions position)
		{
			switch (position)
			{
				case ListPositions.First:
					Remove(0);
					break;
				case ListPositions.Last:
					Remove(Count - 1);
					break;
			}
		}

		public T this[int index]
		{
			get
			{
				return Items[index];
			}
		}
	}
}