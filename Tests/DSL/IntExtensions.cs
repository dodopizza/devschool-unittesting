using System.Collections.Generic;
using Domain;

namespace Tests.DSL
{
    public static class IntExtensions
    {
        public static IEnumerable<Player> Players(this int value)
        {
            for (var i = 0; i < value; i++)
            {
                yield return new Player();
            }
        }

        public static Chip Chips(this int amount)
        {
            return new Chip(amount);
        }

        public static int Score(this int amount)
        {
            return amount;
        }
    }
}