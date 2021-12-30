using System;
using System.Collections.Generic;
namespace TestPr
{
    class CompareAuthorsPap: IComparer<Paper>
    {
        public int Compare(Paper paper1,Paper paper2)
        {
            return String.Compare(paper1.PubAuthor.Surname, paper2.PubAuthor.Surname);
        }
    }
}
