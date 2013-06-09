using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{

        public class TeamLogo : Game
{
    public string size { get; set; }
    public string url { get; set; }
}

public class TeamLogos : Game
{
    public TeamLogo team_logo { get; set; }
}

public class RosterAdds : Game
{
    public string coverage_type { get; set; }
    public string coverage_value { get; set; }
    public string value { get; set; }
}

public class Manager : Game
{
    public string manager_id { get; set; }
    public string nickname { get; set; }
    public string guid { get; set; }
    public string is_commissioner { get; set; }
    public string is_current_login { get; set; }
}

public class Managers : Game
{
    public Manager manager { get; set; }
}

public class Team : Game
{
    public string team_key { get; set; }
    public string team_id { get; set; }
    public string name { get; set; }
    public string is_owned_by_current_login { get; set; }
    public string url { get; set; }
    public TeamLogos team_logos { get; set; }
    public object waiver_priority { get; set; }
    public string number_of_moves { get; set; }
    public string number_of_trades { get; set; }
    public RosterAdds roster_adds { get; set; }
    public Managers managers { get; set; }
}

public class Teams : Game
{
    public Team team { get; set; }
}

public class Game 
{
    public string game_key { get; set; }
    public string game_id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
    public string type { get; set; }
    public string url { get; set; }
    public string season { get; set; }
    public Teams teams { get; set; }
}
    
}
