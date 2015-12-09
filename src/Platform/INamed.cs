// Copyright (c) 2014 Thong Nguyen (tumtumtum@gmail.com)

namespace Platform
{
	/// <summary>
	/// Interface implemented by classes which support a readonly <c>Name</c> property.
	/// </summary>
	public interface INamed
	{
		/// <summary>
		/// Gets the name of the object.
		/// </summary>
		string Name { get; }
	}
}
