using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (egg.IsDone() == false)
            {
                if (bunny.Energy == 0 || bunny.Dyes.All(x => x.IsFinished()))
                {
                    break;
                }

                IDye dye = (IDye)bunny.Dyes.First();
                dye.Use();
                egg.GetColored();
                bunny.Work();

                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }
            }
        }
    }
}
