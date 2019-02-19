using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    public interface IAnimal
    {
        // Interface must have same access level
        // so no modifiers

        // We don't have fields in interfaces but we do have properties
        // because they are kind of like methods
        // doesn't necessarily mean auto-implemented property

        int Id { get; set; }
        string Name { get; set; }

        void MakeNoise();
        void GoTo(string location);
    }
}
