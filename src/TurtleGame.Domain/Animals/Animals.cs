using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Animals.Types;
using TurtleGame.Domain.Common;

namespace TurtleGame.Domain.Animals
{
    public class Animals : EntitiesCollectionsBase<Animal>, IAnimals
    {
        public Animals(IEnumerable<Animal> animals) : base(animals.ToList())
        {

        } 
    }
}