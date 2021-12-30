using System;
namespace TestPr
{
    public class TeamsJournalEntry
    {

        public string CollectionName
        {
            get;
            set;
        }

        public Revision WhatCaused
        {
            get;
            set;
        }

        public string PropertyName
        {
            get;
            set;
        }

        public int RegNumberChange
        {
            get;
            set;
        }

        public TeamsJournalEntry(string CollectionNameValue, Revision WhatCausedValue, string PropertyNameValue, int RegNumberChangeValue)
        {
            CollectionName = CollectionNameValue;
            WhatCaused = WhatCausedValue;
            PropertyName = PropertyNameValue;
            RegNumberChange = RegNumberChangeValue;
        }

        public override string ToString()
        {
            return "Collection Name: " + CollectionName + "\n" +
                "What caused the event: " + WhatCaused + "\n" +
                "Modified Property: " + PropertyName + "\n" +
                "registration number of changed object: " + RegNumberChange;
        }

    }
}
