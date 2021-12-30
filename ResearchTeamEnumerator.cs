using System;
using System.Collections;
using System.Collections.Generic;

namespace TestPr
{
    class ResearchTeamEnumerator :  IEnumerator
    {
        private List<Person> pubPersonList;
        private List<Paper> pubPaperList;
        int index = -1;

        public ResearchTeamEnumerator(List<Person> pubPersonListValue, List<Paper> pubPaperListpArrValue)
        {
            pubPersonList = new List<Person>(pubPersonListValue);
            pubPaperList = new List<Paper>(pubPaperListpArrValue);
        }



       

        // Реализуем интерфейс IEnumerator
        public bool MoveNext()
        {
            if (index == pubPersonList.Count - 1)
            {
                Reset();
                return false;
            }

            index++;
            int count = 0;
                for (int j = 0; j < pubPaperList.Count; j++)
                {

                Paper paper = pubPaperList[j] as Paper;
                    if (paper.PubAuthor.Equals(Current))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {

                    return true;
                }
            

            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return pubPersonList[index];
            }
        }
    }

}
