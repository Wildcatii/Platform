using System.Xml;
using System.Configuration;
using Platform.Xml.Serialization;

namespace Platform
{
	public class XmlConfigurationBlockSectionHandler<T>
		: IConfigurationSectionHandler
		where T : new()
	{
		public object Create(object parent, object configContext, XmlNode section)
		{
			var serializer = XmlSerializer<T>.New();

			var retval = serializer.Deserialize(new XmlNodeReader(section));

			return retval;
		}
	}
}
