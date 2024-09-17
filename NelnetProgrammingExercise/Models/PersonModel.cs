using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public PetClassification PreferredClassification { get; set; }
        public PetType PreferredType { get; set; }
        public WeightClassification PreferredWeight { get; set; }
        public HashSet<PetType> TypeOverrides { get; set; }
        public HashSet<PetClassification> ClassificationOverrides { get; set; }
        public HashSet<WeightClassification> WeightClassificationOverrides { get; set; }

        public PersonModel()
        {
            TypeOverrides = new HashSet<PetType>();
            ClassificationOverrides = new HashSet<PetClassification>();
            WeightClassificationOverrides = new HashSet<WeightClassification>();
        }
    }
}