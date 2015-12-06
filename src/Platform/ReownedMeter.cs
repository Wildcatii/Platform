// Copyright (c) 2014 Thong Nguyen (tumtumtum@gmail.com)

namespace Platform
{
	/// <summary>
	/// A <see cref="MeterWrapper"/> that allows a meter's owner to be changed.
	/// </summary>
	public class ReownedMeter
		: MeterWrapper
	{
		/// <summary>
		/// Creates a new <see cref="ReownedMeter"/>
		/// </summary>
		/// <param name="newOwner">The new owner for the meter</param>
		/// <param name="meter">The meter to wrap</param>
		public ReownedMeter(object newOwner, IMeter meter)
			: base(meter)
		{
			this.Owner = newOwner;
		}

		public override object Owner { get; }
	}
}
