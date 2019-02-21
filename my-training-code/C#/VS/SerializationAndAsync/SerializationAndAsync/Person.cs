using System.Xml.Serialization;

namespace SerializationAndAsync
{
    // classes to be serialized/deserialized (DTO's, data transfer objects)
    // should be POCOs (Plain old C# objects)
    // which means, it must have a zero-parameter constructor
    // and publuc get-set properties

    public class Person
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute("FullName")]
        public string Name { get; set; }

        [XmlElement(ElementName ="StreetAddress")]
        public Address Address { get; set; }
    }
}
