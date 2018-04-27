using Solution.Locator.Games.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Locator.Home.Dto
{
    public class HomeDetails
    {
        public int GamesAvailable { get; set; }

        public Dictionary<string , string> GamesBorrowed { get; set; }

        public int Friends { get; set; }
    }
}
