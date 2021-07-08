using System;

namespace _07.MilitaryElite
{
    using Iterfaces;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] soldierInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string soldierType = soldierInfo[0];
                string id = soldierInfo[1];
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];
                decimal salary = decimal.Parse(soldierInfo[4]);

                if (soldierType == "Private")
                {
                    Private privateSoldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(privateSoldier);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    LieutenantGeneral ltnGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < soldierInfo.Length; i++)
                    {
                        var currPrivateId = soldiers.FirstOrDefault(n => n.Id == soldierInfo[i]);
                        ltnGeneral.Privates.Add((IPrivate)currPrivateId);
                    }

                    soldiers.Add(ltnGeneral);
                }
                else if (soldierType == "Engineer")
                {
                    string corp = soldierInfo[5];

                    if (corp == "Airforces" || corp == "Marines")
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corp);

                        for (int i = 6; i < soldierInfo.Length - 1; i += 2)
                        {
                            string part = soldierInfo[i];
                            int hours = int.Parse(soldierInfo[i + 1]);

                            Repair repair = new Repair(part, hours);
                            engineer.Repairs.Add(repair);
                        }

                        soldiers.Add(engineer);
                    }
                }
                else if (soldierType == "Commando")
                {
                    string corp = soldierInfo[5];

                    if (corp == "Airforces" || corp == "Marines")
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corp);

                        for (int i = 6; i < soldierInfo.Length -1; i++)
                        {
                            string codeName = soldierInfo[i];
                            string state = soldierInfo[i + 1];

                            if (state == "Finished" || state == "inProgress")
                            {
                                Mission mission = new Mission(codeName, state);
                                commando.Missions.Add(mission);
                            }
                        }

                        soldiers.Add(commando);
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldierInfo[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine,soldiers));
        }
    }
}
