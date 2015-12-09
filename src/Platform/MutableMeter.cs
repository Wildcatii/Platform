// Copyright (c) 2014 Thong Nguyen (tumtumtum@gmail.com)

using System;

namespace Platform
{
	/// <summary>
	/// An <see cref="IMeter"/> implementation that stores the actual
	/// values of the maximum and minimum values.
	/// </summary>
	public class MutableMeter
		: AbstractMeter
	{
		/// <summary>
		/// Gets or sets the function that generates a string for the current meter.
		/// </summary>
		public virtual Func<MutableMeter, Func<string>, string> ToStringGenerator { get; set; }

		/// <summary>
		/// Constructs a new blank <see cref="MutableMeter"/>.
		/// </summary>
		public MutableMeter()
			: this(null, null, null, "")
		{
		}

		/// <summary>
		/// Constructs a new <see cref="MutableMeter"/>.
		/// </summary>
		/// <param name="minimumValue">The <see cref="MinimumValue"/></param>
		/// <param name="maximumValue">The <see cref="MaximumValue"/></param>
		/// <param name="currentValue">The <see cref="CurrentValue"/></param>
		/// <param name="units">The <see cref="Units"/></param>
		public MutableMeter(object minimumValue, object maximumValue, object currentValue, string units)
			: this(null, minimumValue, maximumValue, currentValue, units)
		{
		}

		/// <summary>
		/// Constructs a new <see cref="MutableMeter"/>.
		/// </summary>
		/// <param name="owner">The owner</param>
		/// <param name="minimumValue">The <see cref="MinimumValue"/></param>
		/// <param name="maximumValue">The <see cref="MaximumValue"/></param>
		/// <param name="currentValue">The <see cref="CurrentValue"/></param>
		/// <param name="units">The <see cref="Units"/></param>
		public MutableMeter(object owner, object minimumValue, object maximumValue, object currentValue, string units)
		{
			this.owner = owner;
			this.minimumValue = minimumValue;
			this.maximumValue = maximumValue;
			this.currentValue = currentValue;
			this.units = units;
		}


		/// <summary>
		/// Gets the current owner.
		/// </summary>
		public override object Owner => this.owner;

		private object owner;

		/// <summary>
		/// Sets the owner of the meter.
		/// </summary>
		/// <param name="value">The owner</param>
		public virtual void SetOwner(object value)
		{
			this.owner = value;
		}
        
		/// <summary>
		/// Gets the units.
		/// </summary>
		public override string Units => this.units;

		private string units;

		/// <summary>
		/// Sets the units.
		/// </summary>
		/// <param name="value">The units</param>
		public virtual void SetUnits(string value)
		{
			units = value;

			OnMajorChange();
		}

		/// <summary>
		/// Gets the minimum value.
		/// </summary>
		public override object MinimumValue
		{
			get
			{
				return minimumValue;
			}
		}
		private object minimumValue;

		/// <summary>
		/// Sets the minimum value.
		/// </summary>
		/// <param name="value">The minimum value</param>
		public virtual void SetMinimumValue(object value)
		{
			minimumValue = value;

			OnMajorChange();
		}

		/// <summary>
		/// Gets the maximum value.
		/// </summary>
		public override object MaximumValue => this.maximumValue;

		private object maximumValue;

		/// <summary>
		/// Sets the maxuimum value.
		/// </summary>
		/// <param name="value">The maximum value</param>
		public virtual void SetMaximumValue(object value)
		{	
			maximumValue = value;

			OnMajorChange();
		}

		/// <summary>
		/// Gets the current value.
		/// </summary>
		public override object CurrentValue => this.currentValue;

		private object currentValue;

		/// <summary>
		/// Sets the current value.
		/// </summary>
		/// <param name="value">The current value</param>
		public virtual void SetCurrentValue(object value)
		{
			var oldValue = this.currentValue;

			currentValue = value;

			OnValueChanged(oldValue, value);
		}

		/// <summary>
		/// Sets the current and maximum value.
		/// </summary>
		/// <param name="value">The current value</param>
		/// <param name="maximumValue">The maximum value</param>
		public virtual void SetCurrentAndMaximumValue(object value, object maximumValue)
		{
			this.maximumValue = maximumValue;

			var oldValue = this.currentValue;

			currentValue = value;

			OnMajorChange();
			OnValueChanged(oldValue, value);
		}

		/// <summary>
		/// Gets a string representation of this object.  <see cref="ToStringGenerator"/>
		/// will be used to generate the string if it is not null otherwise the default
		/// from <see cref="AbstractMeter.ToString()"/> will be used. 
		/// </summary>
		/// <returns>
		/// A string representation of this object.
		/// </returns>
		public override string ToString()
		{
			if (this.ToStringGenerator != null)
			{
				return ToStringGenerator(this, base.ToString);
			}

			return base.ToString();
		}
	}
}
