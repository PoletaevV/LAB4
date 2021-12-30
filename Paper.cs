using System;
using System.Collections.Generic;
namespace TestPr
{
    class Paper : IComparable<Paper>, IComparer<Paper>
    {
        public string PubTitle { get; set; }
        public Person PubAuthor { get; set; }
        public DateTime PubDate { get; set; }

        public int CompareTo(Paper paper2)
        {
            return this.PubDate.CompareTo(paper2.PubDate);
        }

        public int Compare(Paper paper1,Paper paper2)
        {
            return String.Compare(paper1.PubTitle, paper2.PubTitle);
        }


        //constructor with parameters
        public Paper(string pubTitleValue, Person pubAuthorValue, DateTime pubDateValue)
        {
            PubTitle = pubTitleValue;
            PubAuthor = pubAuthorValue;
            PubDate = pubDateValue;
        }


        //constructor without parameters
        public Paper() : this("Capital", new Person("Carl","Marks",new DateTime(1818,3,14)), new DateTime(1867, 1, 1))
        {
        }

        //output
        public override string ToString()
        {
            return PubTitle+" "+PubAuthor.ToString()+" "+PubDate.Day+" "+PubDate.Month+" "+PubDate.Year;
        }

        public virtual Paper DeepCopy()
        {
            return new Paper(this.PubTitle, this.PubAuthor, this.PubDate);
        }
    }
}
