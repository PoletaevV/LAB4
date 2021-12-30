using System;
using System.Collections.Generic;

namespace TestPr
{
    public class TeamsJournal
    {
        private List<TeamsJournalEntry> ChangedList=new List<TeamsJournalEntry>();

        public TeamsJournal()
        {
        }
        public override string ToString()
        {
            string str = "TeamsJournal\n";
            foreach (TeamsJournalEntry teams in ChangedList)
            {
                str += teams.ToString() + "\n";
            }

            return str;
        }

        public void ResearchTeamsChangedHandler(object sendler, ResearchTeamsChangedEventArgs<string> args)
        {
            ChangedList.Add(new TeamsJournalEntry(args.CollectionName, args.WhatCaused, args.PropertyName, args.RegNumberChange));
        }
    }
}
