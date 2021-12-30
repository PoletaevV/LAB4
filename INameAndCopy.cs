using System;
namespace TestPr
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
