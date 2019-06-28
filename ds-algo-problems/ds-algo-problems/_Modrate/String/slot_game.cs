using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.String
{
    public class slot_game
    {
        // You are given a solution string. e.g. BRGY
        // You are given a guess string. 
        // When you find guess char in same poistion its hit.
        // if you find same char in different position its pseudo-hit
        // Calculate number of hit and pseudo-hit

        public List<int> CalculateHit(string solution, string guess)
        {
            int count = 0;
            List<int> hitIndexes = new List<int>();
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < solution.Length; i++)
            {
                if(i < guess.Length && solution[i] == guess[i])
                {
                    count++;
                    hitIndexes.Add(i);
                }
                else
                {
                    if (map.ContainsKey(solution[i]))
                    {
                        map[solution[i]]++;
                    }
                    else
                    {
                        map.Add(solution[i], 1);
                    }
                }
            }
            int pseudoHit = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (hitIndexes.Contains(i)) continue;
                else
                {
                    if(map.ContainsKey(guess[i]))
                    {
                        pseudoHit++;
                        map[guess[i]]--;
                        if (map[guess[i]] == 0)
                        {
                            map.Remove(guess[i]);
                        }
                    }
                }
            }

            Console.Write($"No of hit: {count}");
            Console.Write($"No of Pseudo-Hit: {pseudoHit}");
            return hitIndexes;
        }
    }
}
