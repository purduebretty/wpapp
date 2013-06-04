using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{
    class TeamClass
    {
        public class Teams
        {
            public List<List<object>> team { get; set; }
        }


        //user
        public class User
        {
            public string guid { get; set; }
        }

        ///game
        ///
        public class Game
        {
            public string game_key { get; set; }
            public string game_id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string type { get; set; }
            public object url { get; set; }
            public string season { get; set; }
        }

        // league

        public class League
        {
            public string league_key { get; set; }
            public string league_id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string draft_status { get; set; }
            public int num_teams { get; set; }
            public string edit_key { get; set; }
            public string weekly_deadline { get; set; }
            public string league_update_timestamp { get; set; }
            public string scoring_type { get; set; }
            public string league_type { get; set; }
            public string is_pro_league { get; set; }
            public string current_week { get; set; }
            public string start_week { get; set; }
            public string start_date { get; set; }
            public string end_week { get; set; }
            public string end_date { get; set; }
            public int is_finished { get; set; }
        }

        public class Manager
        {
            public string manager_id { get; set; }
            public string nickname { get; set; }
            public string is_current_login { get; set; }
        }

        //public class Roster 
        //{
        //    public string player_key { get; set; }
        //    public string player_id { get; set; }
        //    public string display_position { get; set; }
        //    public string player_key { get; set; }
        //    public string player_key { get; set; }
        //    public string player_key { get; set; }



        //}

    }
}
