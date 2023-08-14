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
        public Agents() { }

        public Dictionary<string, Agents> agentsDictionary = new Dictionary<string, Agents>();
        public void InitializeDictionary()
        {
            // row 1
            agentsDictionary.Add("Astra", new Agents(544, 926));
            agentsDictionary.Add("Breach", new Agents(628, 926));
            agentsDictionary.Add("Brimstone", new Agents(710, 926));
            agentsDictionary.Add("Chamber", new Agents(792, 926));
            agentsDictionary.Add("Cypher", new Agents(880, 926));
            agentsDictionary.Add("Deadlock", new Agents(960, 926));
            agentsDictionary.Add("Fade", new Agents(1050, 926));
            agentsDictionary.Add("Gekko", new Agents(1130, 926));
            agentsDictionary.Add("Harbor", new Agents(1230, 926));
            agentsDictionary.Add("Jett", new Agents(1300, 926));
            agentsDictionary.Add("KAYO", new Agents(1381, 926));
            // row 2
            agentsDictionary.Add("Killjoy", new Agents(544, 1005));
            agentsDictionary.Add("Neon", new Agents(628, 1005));
            agentsDictionary.Add("Omen", new Agents(710, 1005));
            agentsDictionary.Add("Phoenix", new Agents(792, 1005));
            agentsDictionary.Add("Raze", new Agents(880, 1005));
            agentsDictionary.Add("Reyna", new Agents(960, 1005));
            agentsDictionary.Add("Sage", new Agents(1050, 1005));
            agentsDictionary.Add("Skye", new Agents(1130, 1005));
            agentsDictionary.Add("Sova", new Agents(1230, 1005));
            agentsDictionary.Add("Viper", new Agents(1300, 1005));
            agentsDictionary.Add("Yoru", new Agents(1381, 1005));
        }
        
    }
    
}
