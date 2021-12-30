using System;
namespace TestPr
{
    class Team:INameAndCopy
    {

        protected string orgName;
        protected int regNumber;
        public Team(string orgNameValue,int regNumberValue)
        {
            orgName = orgNameValue;
            regNumber = regNumberValue;
        }
        public Team()
        {
            orgName = "MMM";
            regNumber = 111;
        }
        public string OrgName { get; set; }
        public int RegNumber
        {
            get
            {
                return regNumber;
            }
            set
            {
                if (value > 0)
                {
                    regNumber = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Incorrect value, please try again");
            }
        }

        public virtual object DeepCopy()
        {
            Team team = new Team();
            team.orgName = this.orgName;
            team.regNumber = this.regNumber;
            return team;
        }

        public override string ToString()
        {
            return "Organisation name: "+orgName+" Registration number: "+regNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Team team = obj as Team;
            if ((System.Object)team == null)
                return false;
            return this.regNumber == team.regNumber && this.orgName == team.orgName;
        }

        public static bool operator ==(Team team1, Team team2) => team1.Equals(team2);
        public static bool operator !=(Team team1, Team team2) => !team1.Equals(team2);

        public override int GetHashCode()
        {
            return this.regNumber.GetHashCode()^this.orgName.GetHashCode();
        }

        string INameAndCopy.Name
        {
            get { return this.orgName; }
            set { this.orgName = value; }
        }

        object INameAndCopy.DeepCopy()
        {
            return this.DeepCopy();
        }
    }
}
