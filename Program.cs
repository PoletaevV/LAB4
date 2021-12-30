using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestPr
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 part
            ResearchTeam RTeam1 = new ResearchTeam("Topic", "MIET", 123, TimeFrame.Year);
            ResearchTeam RTeam2 = new ResearchTeam("Topic2", "MGU", 11, TimeFrame.TwoYears);
            ResearchTeamCollection<string> RTColl1 = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.generateKey);
            RTColl1.CollectionName = "Some name1";
            RTColl1.AddResearchTeams(RTeam1);
            ResearchTeamCollection<string> RTColl2 = new ResearchTeamCollection<string>(ResearchTeamCollection<string>.generateKey);
            RTColl2.CollectionName = "Some name2";
            RTColl2.AddResearchTeams(RTeam2);
            //2 part
            TeamsJournal journal = new TeamsJournal();
            RTColl1.ResearchTeamsChanged += journal.ResearchTeamsChangedHandler;
            RTColl2.ResearchTeamsChanged += journal.ResearchTeamsChangedHandler;

            //3 part
            RTColl1.AddResearchTeams(new ResearchTeam("Topic3", "MIET", 12, TimeFrame.Long));
            RTColl2.AddResearchTeams(new ResearchTeam("Topic4", "MGU", 3, TimeFrame.Year));

            RTColl1.resteam["Topic"].Duration = TimeFrame.TwoYears;
            RTColl2.resteam["Topic4"].RegNumber = 124;

            RTColl1.Remove(RTeam1);
            try
            {
                RTColl1.resteam["Topic"].Duration = TimeFrame.Long;
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            ResearchTeam RTeam3 = new ResearchTeam("Topic5", "MFTI",67 ,TimeFrame.Long);
            RTColl2.Replace(RTeam2, RTeam3);
            try
            {
                RTColl2.resteam["Topic2"].Duration = TimeFrame.Year;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            //4 part
            Console.WriteLine(journal);

            
        }
    }
}
