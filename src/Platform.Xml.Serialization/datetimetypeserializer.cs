using System;

namespace Platform.Xml.Serialization
{
	public class DateTimeTypeSerializer
		: TypeSerializerWithSimpleTextSupport
	{
		private readonly bool formatSpecified = false;

		private readonly XmlDateTimeFormatAttribute formatAttribute;

		public override bool MemberBound => true;

		public override Type SupportedType => typeof(DateTime);

		public DateTimeTypeSerializer(SerializationMemberInfo memberInfo, TypeSerializerCache cache, SerializerOptions options)
		{
			formatAttribute = (XmlDateTimeFormatAttribute)memberInfo.GetFirstApplicableAttribute(typeof(XmlDateTimeFormatAttribute));
			
			if (formatAttribute == null)
			{				
				formatAttribute = new XmlDateTimeFormatAttribute("G");
				formatSpecified = false;
			}
			else
			{
				formatSpecified = true;
 			}
		}

		public override string Serialize(object obj, SerializationContext state)
		{
			return ((DateTime)obj).ToString(formatAttribute.Format);
		}

		public override object Deserialize(string value, SerializationContext state)
		{
			if (formatSpecified)
			{
				try
				{
					return DateTime.ParseExact(value, formatAttribute.Format, System.Globalization.CultureInfo.CurrentCulture);
				}
				catch 
				{				
				}
			}

			return DateTime.Parse(value);
		}
	}
}