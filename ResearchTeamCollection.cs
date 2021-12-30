using System;
using System.Collections.Generic;
using System.Linq;
namespace TestPr
{
    delegate TKey KeySelector<TKey>(ResearchTeam researchTeam);
    class ResearchTeamCollection<TKey>
    {
        public Dictionary<TKey, ResearchTeam> resteam;
        private KeySelector<TKey> keySelector;
        public ResearchTeamCollection(KeySelector<TKey> keySelectorvalue)
        {
            keySelector = keySelectorvalue;
            resteam = new Dictionary<TKey, ResearchTeam>();
        }
        public void AddDefaults()
        {
            ResearchTeam researchTeam = new ResearchTeam();
            researchTeam.AddPapers(new Paper());
            researchTeam.AddParticipants(new Person());
            TKey key = keySelector(researchTeam);
            resteam.Add(key, researchTeam);
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            for (int i= 0; i < researchTeams.Length;i++)
            {
                TKey key = keySelector(researchTeams[i]);
                resteam.Add(key, researchTeams[i]);
            }
        }

        public override string ToString()
        {
            Dictionary<TKey, ResearchTeam>.ValueCollection valueCol = resteam.Values;
            string str = "";
            foreach (ResearchTeam val in valueCol)
                str += val.ToString() + "\n\n";
            return str;
        }

        public string ToShortString()
        {
            Dictionary<TKey, ResearchTeam>.ValueCollection valueCol = resteam.Values;
            string str = "";
            foreach (ResearchTeam val in valueCol)
                str += val.ToShortString() + " count of pesons: " + val.PubParticipants.Count + " count of papers: " + val.PubList.Count + "\n\n";
            return str;
        }


        public DateTime LastestPaper
        {
            get
            {
                Dictionary<TKey, ResearchTeam>.ValueCollection valueCol = resteam.Values;
                if (valueCol.Count == 0)
                    return new DateTime();
                else
                {
                    List<Paper> papers = new List<Paper>();
                    foreach (ResearchTeam researchTeam in valueCol)
                        papers.Add(researchTeam.LastPub);
                    return papers.Max(pap => pap.PubDate);
                }
            }
        }


        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame value)
        {
            return resteam.Where(resteam=>resteam.Value.Duration==value);
        }

        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> groupDur
        {
            get
            {
                return resteam.GroupBy(pair => pair.Value.Duration);
            }
        }
        
        public static string generateKey(ResearchTeam researchTeam)
        {
            //return researchTeam.team.ToString();
            return researchTeam.ResTopic;
        }


        public string CollectionName
        {
            get;
            set;
        }

        public bool Remove(ResearchTeam rt)
        {
            if (resteam.ContainsValue(rt))
                foreach (KeyValuePair<TKey, ResearchTeam> pair in resteam)
                    if (rt==pair.Value)
                    {
                        resteam.Remove(pair.Key);
                        ResearchTeamsChanged?.Invoke(resteam,new ResearchTeamsChangedEventArgs<TKey>(CollectionName,Revision.Remove,"",rt.RegNumber));
                        return true;
                    }
            return false;

        }

        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            if (resteam.ContainsValue(rtold))
                foreach (KeyValuePair<TKey, ResearchTeam> pair in resteam)
                    if (rtold == pair.Value)
                    {
                        resteam.Remove(pair.Key);
                        AddResearchTeams(rtnew);
                        ResearchTeamsChanged?.Invoke(resteam, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Replace, "", rtold.RegNumber));
                        return true;
                    }
            return false;

        }

        public event ResearchTeamsChangedHandler<TKey> ResearchTeamsChanged;

    }
}
