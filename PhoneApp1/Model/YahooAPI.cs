﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{
    public class JSONName
    {
        public string full { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string ascii_first { get; set; }
        public string ascii_last { get; set; }
    }

    public class ByeWeeks
    {
        public string week { get; set; }
    }

    public class JSONHeadshot
    {
        public string hdurl
        {
            get
            {
                string _largeImage = this.url;

                if (this.url != null && _largeImage.IndexOf("--/http") > 0)
                {
                    _largeImage = _largeImage.Substring(_largeImage.IndexOf("--/http") + 3);
                }
                return _largeImage;

            }
            set
            {
                hdurl = value;
            }
        }
        public string url  {get; set;}
        public string size { get; set; }
    }

    public class EligiblePositions
    {
        public string position { get; set; }
    }

    public class PercentOwned
    {
        public string coverage_type { get; set; }
        public string week { get; set; }
        public string delta { get; set; }
    }

    public class JSONPlayer
    {
        public string player_key { get; set; }
        public string player_id { get; set; }
        public JSONName name { get; set; }
        public string status { get; set; }
        public string editorial_player_key { get; set; }
        public string editorial_team_key { get; set; }
        public string editorial_team_full_name { get; set; }
        public string editorial_team_abbr { get; set; }
        public ByeWeeks bye_weeks { get; set; }
        public string uniform_number { get; set; }
        public string display_position { get; set; }
        public JSONHeadshot headshot { get; set; }
        public string image_url { get; set; }
        public string is_undroppable { get; set; }
        public string position_type { get; set; }
        public EligiblePositions eligible_positions { get; set; }
    }
}
