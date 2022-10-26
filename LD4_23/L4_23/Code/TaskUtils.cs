using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4_23.Code
{
    public class TaskUtils
    {
        /// <summary>
        /// Finds Heaviest Juvelry
        /// </summary>
        /// <param name="juvelries"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<Juvelry> FindHeaviest(List<Juvelry> juvelries)
        {
            var list = new List<Juvelry>();
            Ring heaviestRing = null;
            Earrings heaviestEarrings = null;
            Chain heaviestChain = null;

            for (int i = 0; i < juvelries.Count; i++)
            {
                Juvelry juwelry = juvelries[i];
                if (juwelry is Ring)
                {
                    Ring ring = juwelry as Ring;
                    if (heaviestRing == null || ring.Weight > heaviestRing.Weight)
                    {
                        heaviestRing = ring;
                    }
                }
                else if (juwelry is Earrings)
                {
                    Earrings earrings = juwelry as Earrings;
                    if (heaviestEarrings == null || earrings.Weight > heaviestEarrings.Weight)
                    {
                        heaviestEarrings = earrings;
                    }
                }
                else if (juwelry is Chain)
                {
                    Chain chain = juwelry as Chain;
                    if (heaviestChain == null || chain.Weight > heaviestChain.Weight)
                    {
                        heaviestChain = chain;
                    }
                }
            }
            if (heaviestRing != null)
            {
                list.Add(heaviestRing);
            }
            if (heaviestChain != null)
            {
                list.Add(heaviestChain);
            }
            if (heaviestEarrings != null)
            {
                list.Add(heaviestEarrings);
            }
            return list;
            throw new NotImplementedException();
        }
        /// <summary>
        /// Finds Highest Carat Juvelries
        /// </summary>
        /// <param name="juvelries"></param>
        /// <returns></returns>
        public static List<Juvelry> FindHighestCarat(List<Juvelry> juvelries)
        {
            var filtered = new List<Juvelry>();
            for (int i = 0; i < juvelries.Count; i++)
            {
                Juvelry juwelry = juvelries[i];
                if (juwelry.Metal == "auksas" && juwelry.Carat == 750)
                {
                    filtered.Add(juwelry);
                }
                else if (juwelry.Metal == "platina" && juwelry.Carat == 950)
                {
                    filtered.Add(juwelry);
                }
                else if (juwelry.Metal == "sidabras" && juwelry.Carat == 925)
                {
                    filtered.Add(juwelry);
                }
                else if (juwelry.Metal == "paladis" && juwelry.Carat == 850)
                {
                    filtered.Add(juwelry);
                }
            }
            return filtered;
        }
        /// <summary>
        /// Finds Highest Carat Juvelry At a Store
        /// </summary>
        /// <param name="juvelries"></param>
        /// <param name="ShopName"></param>
        /// <returns></returns>
        public static int FindHighestCaratAtStore(List<Juvelry> juvelries, string ShopName)
        {
            int highestCarat = 0;
            for (int i = 0; i < juvelries.Count; i++)
            {
                if (juvelries[i].ShopName == ShopName)
                {
                    highestCarat = FindHighestCarat(juvelries).Count();
                }
            }
            return highestCarat;
        }
        /// <summary>
        /// Groups Juvleries by store Name
        /// </summary>
        /// <param name="juvelries"></param>
        /// <returns></returns>
        private static Dictionary<string, List<Juvelry>> GroupJuwelsByStore(List<Juvelry> juvelries)
        {
            var result = new Dictionary<string, List<Juvelry>>();
            for (int i = 0; i < juvelries.Count; i++)
            {
                var juwelry = juvelries[i];
                if (result.ContainsKey(juwelry.ShopName))
                {
                    result[juwelry.ShopName].Add(juwelry);
                }
                else
                {
                    result[juwelry.ShopName] = new List<Juvelry>();
                    result[juwelry.ShopName].Add(juwelry);
                }
            }
            return result;
        }
        /// <summary>
        /// Finds Juvelries That are in All stores
        /// </summary>
        /// <param name="juvelries"></param>
        /// <returns></returns>
        public static List<Juvelry> IsInBothStores(List<Juvelry> juvelries)
        {
            var Filtered = new List<Juvelry>();
            var stores = GroupJuwelsByStore(juvelries);
            foreach (var store1 in stores)
            {
                for (int i = 0; i < store1.Value.Count; i++)
                {
                    bool good = true;
                    foreach (var store2 in stores)
                    {
                        if (!store2.Value.Contains(store1.Value[i]))
                        {
                            good = false;
                            break;
                        }
                    }
                    if (good && !Filtered.Contains(store1.Value[i]))
                    {
                        Filtered.Add(store1.Value[i]);
                    }
                }
            }
            return Filtered;
        }
        public static List<Juvelry> FindExpensive(List<Juvelry> juvelries)
        {
            var Filtered = new List<Juvelry>();
            for (int i = 0; i < juvelries.Count; i++)
            {
                if (juvelries[i].Type == "Ring")
                {
                    if (juvelries[i].Price > 500)
                    {
                        Filtered.Add(juvelries[i]);
                    }
                }
                else if (juvelries[i].Type == "Earrings")
                {
                    if (juvelries[i].Price > 300)
                    {
                        Filtered.Add(juvelries[i]);
                    }
                }
                else if (juvelries[i].Type == "Chain")
                {
                    if (juvelries[i].Price > 150)
                    {
                        Filtered.Add(juvelries[i]);
                    }
                }
            }
            return Filtered;
        }

    }
}