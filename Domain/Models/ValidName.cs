using System;
namespace Domain.Models.Fuels
{
    public class ValidName

    {
        public string Name { get; }

        public ValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception($"{nameof(name)} is invalid.");
            Name = name;
        }
    }
}
