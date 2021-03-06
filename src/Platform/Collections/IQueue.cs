using System;
using System.Collections.Generic;

namespace Platform.Collections
{
	/// <summary>
	/// Interface for all objects that implement a queue.
	/// </summary>
	/// <typeparam name="T">The type of value stored in the queue</typeparam>
	public interface IQueue<T>
		: ICollection<T>
	{
		/// <summary>
		/// Enqueues an item onto the collection.
		/// </summary>
		/// <param name="item"></param>
		void Enqueue(T item);
		
		/// <summary>
		/// Enqueues an array of items into the queue.
		/// </summary>
		/// <param name="items">The array of items to enqueue</param>
		/// <param name="offset">The offset within the array to start enqueing from</param>
		/// <param name="count">The number of items from the array to enqueue</param>
		void Enqueue(T[] items, int offset, int count);

		/// <summary>
		/// Dequeues the next item in the collection.
		/// </summary>
		/// <exception cref="InvalidOperationException">When an item is not available</exception>
		/// <returns>The next item in the queue (an exception is thrown if none is available)</returns>
		T Dequeue();

		/// <summary>
		/// Tries to dequeue the next item in the collection.
		/// </summary>
		/// <param name="item">A variable to store the value if available</param>
		/// <returns>True if an item is available and has been returned otherwise False</returns>
		bool TryDequeue(out T item);

		/// <summary>
		/// Returns the next item in the queue without removing it from the queue.
		/// </summary>
		/// <exception cref="InvalidOperationException">No item is avilable in the queue</exception>
		/// <returns>The next item if one is available otherwise throws an <see cref="InvalidOperationException"/></returns>
		T Peek();

		/// <summary>
		/// Returns the next item in the queue without removing it from the queue.
		/// </summary>
		/// <param name="item">A variable to store the next item</param>
		/// <exception cref="InvalidOperationException">No item is avilable in the queue</exception>
		/// <returns>True if an item was available and returned</returns>
		bool TryPeek(out T item);
	}
}
