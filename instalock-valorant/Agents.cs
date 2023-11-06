using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instalock_valorant
{
    internal class Agents
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Agents(int x, int y)
        {
            X = x;
            Y = y;
        }

        int lockInX = 960;
        int lockInY = 730;

        public Agents() { }

        public Dictionary<string, Agents> agentsDictionary = new Dictionary<string, Agents>();
        public void InitializeDictionary()
        {
            // row 1

            agentsDictionary.Add("Astra", new Agents(627, 843));
            agentsDictionary.Add("Breach", new Agents(703, 843));
            agentsDictionary.Add("Brimstone", new Agents(789, 843));
            agentsDictionary.Add("Chamber", new Agents(868, 843));
            agentsDictionary.Add("Cypher", new Agents(960, 843));
            agentsDictionary.Add("Deadlock", new Agents(1042, 843));
            agentsDictionary.Add("Fade", new Agents(1125, 843));
            agentsDictionary.Add("Gekko", new Agents(1210, 843));
            agentsDictionary.Add("Harbor", new Agents(1294, 843));

            // row 2

            agentsDictionary.Add("Iso", new Agents(627, 927));
            agentsDictionary.Add("Jett", new Agents(703, 927));
            agentsDictionary.Add("KAYO", new Agents(789, 927));
            agentsDictionary.Add("Killjoy", new Agents(868, 927));
            agentsDictionary.Add("Neon", new Agents(960, 927));
            agentsDictionary.Add("Omen", new Agents(1042, 927));
            agentsDictionary.Add("Phoenix", new Agents(1125, 927));
            agentsDictionary.Add("Raze", new Agents(1210, 927));
            agentsDictionary.Add("Reyna", new Agents(1294, 927));

            // row 3

            agentsDictionary.Add("Sage", new Agents(627, 1005));
            agentsDictionary.Add("Skye", new Agents(703, 1005));
            agentsDictionary.Add("Sova", new Agents(789, 1005));
            agentsDictionary.Add("Viper", new Agents(868, 1005));
            agentsDictionary.Add("Yoru", new Agents(960, 1005));
        }

    }
    
}
