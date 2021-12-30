using System;
using System.Collections.Generic;
using System.Text;
namespace TestPr
{
    class Person
    {
        string name;
        string surname;
        DateTime birthday;

        //constructor with parameters
        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }


        //constructor without parameters
        public Person() : this("Ivan", "Ivanov", new DateTime(2000, 1, 1))
        {
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public int BirthdayYear
        {
            get
            {
                return Birthday.Year;
            }
            set
            {
                Birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }
        }

        //outputs
        public override string ToString()
        {
            return "("+Name + " " + Surname + " " + Birthday.Day + " " + Birthday.Month + " " + Birthday.Year+")";
        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }
        public override bool Equals(object obj)
        {
            Person pers = obj as Person;
            if (pers.surname == surname && pers.name == name && pers.birthday == birthday) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return surname.GetHashCode() ^ name.GetHashCode() ^ birthday.GetHashCode();
        }
        public Person DeepCopy()
        {
            return new Person { birthday = this.birthday, surname = this.surname, name = this.name };
        }

        public static bool operator ==(Person pers1, Person pers2) => pers1.Equals(pers2);
        public static bool operator !=(Person pers1, Person pers2) => !pers1.Equals(pers2);
    }
} 
