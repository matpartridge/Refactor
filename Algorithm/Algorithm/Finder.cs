using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Thing> Person;

        public Finder(List<Thing> p)
        {
            this.Person = p;
        }

        public F Find(FT ft)
        {
            var tr = new List<F>();

            for(var i = 0; i < this.Person.Count - 1; i++)
            {
                for(var j = i + 1; j < this.Person.Count; j++)
                {
                    var r = new F();
                    if(this.Person[i].BirthDate < this.Person[j].BirthDate)
                    {
                        r.P1 = this.Person[i];
                        r.P2 = this.Person[j];
                    }
                    else
                    {
                        r.P1 = this.Person[j];
                        r.P2 = this.Person[i];
                    }
                    r.D = r.P2.BirthDate - r.P1.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new F();
            }

            F answer = tr[0];
            foreach(var result in tr)
            {
                switch(ft)
                {
                    case FT.One:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case FT.Two:
                        if(result.D > answer.D)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}