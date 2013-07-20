﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{
    public class StringObject 
    {
        public string StringValue { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng", IsNullable = false)]
    public partial class fantasy_content
    {

        private Team teamField;

        private string langField;

        private string uriField;

        private string timeField;

        private string copyrightField;

        private byte refresh_rateField;

        private Roster rosterField;

        /// <remarks/>
        public Team team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.yahooapis.com/v1/base.rng")]
        public string uri
        {
            get
            {
                return this.uriField;
            }
            set
            {
                this.uriField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string copyright
        {
            get
            {
                return this.copyrightField;
            }
            set
            {
                this.copyrightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte refresh_rate
        {
            get
            {
                return this.refresh_rateField;
            }
            set
            {
                this.refresh_rateField = value;
            }
        }

        public Roster roster
        {
            get
            {
                return this.rosterField;
            }
            set
            {
                this.rosterField = value;
            }
        }

    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Team
    {

        private string team_keyField;

        private byte team_idField;

        private string nameField;

        private string current_weekField;

        private byte is_owned_by_current_loginField;

        private string urlField;

        private Team_logos team_logosField;

        private string waiver_priorityField;

        private byte number_of_movesField;

        private byte number_of_tradesField;

        private Roster_adds roster_addsField;

        private byte clinched_playoffsField;

        private Managers managersField;

        private Roster rosterField;

        /// <remarks/>
        public string team_key
        {
            get
            {
                return this.team_keyField;
            }
            set
            {
                this.team_keyField = value;
            }
        }

        /// <remarks/>
        public byte team_id
        {
            get
            {
                return this.team_idField;
            }
            set
            {
                this.team_idField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public string current_week
        {
            get
            {
                return this.current_weekField;
            }
            set
            {
                this.current_weekField = value;
            }
        }


        /// <remarks/>
        public byte is_owned_by_current_login
        {
            get
            {
                return this.is_owned_by_current_loginField;
            }
            set
            {
                this.is_owned_by_current_loginField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public Team_logos team_logos
        {
            get
            {
                return this.team_logosField;
            }
            set
            {
                this.team_logosField = value;
            }
        }

        /// <remarks/>
        public string waiver_priority
        {
            get
            {
                return this.waiver_priorityField;
            }
            set
            {
                this.waiver_priorityField = value;
            }
        }

        /// <remarks/>
        public byte number_of_moves
        {
            get
            {
                return this.number_of_movesField;
            }
            set
            {
                this.number_of_movesField = value;
            }
        }

        /// <remarks/>
        public byte number_of_trades
        {
            get
            {
                return this.number_of_tradesField;
            }
            set
            {
                this.number_of_tradesField = value;
            }
        }

        /// <remarks/>
        public Roster_adds roster_adds
        {
            get
            {
                return this.roster_addsField;
            }
            set
            {
                this.roster_addsField = value;
            }
        }

        /// <remarks/>
        public byte clinched_playoffs
        {
            get
            {
                return this.clinched_playoffsField;
            }
            set
            {
                this.clinched_playoffsField = value;
            }
        }

        /// <remarks/>
        public Managers managers
        {
            get
            {
                return this.managersField;
            }
            set
            {
                this.managersField = value;
            }
        }

        /// <remarks/>
        public Roster roster
        {
            get
            {
                return this.rosterField;
            }
            set
            {
                this.rosterField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Team_logos
    {

        private Team_logo team_logoField;

        /// <remarks/>
        public Team_logo team_logo
        {
            get
            {
                return this.team_logoField;
            }
            set
            {
                this.team_logoField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Team_logo
    {

        private string sizeField;

        private string urlField;

        /// <remarks/>
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Roster_adds
    {

        private string coverage_typeField;

        private byte coverage_valueField;

        private byte valueField;

        /// <remarks/>
        public string coverage_type
        {
            get
            {
                return this.coverage_typeField;
            }
            set
            {
                this.coverage_typeField = value;
            }
        }

        /// <remarks/>
        public byte coverage_value
        {
            get
            {
                return this.coverage_valueField;
            }
            set
            {
                this.coverage_valueField = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Managers
    {

        private Manager managerField;

        /// <remarks/>
        public Manager manager
        {
            get
            {
                return this.managerField;
            }
            set
            {
                this.managerField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Manager
    {

        private byte manager_idField;

        private string nicknameField;

        private string guidField;

        private byte is_current_loginField;

        /// <remarks/>
        public byte manager_id
        {
            get
            {
                return this.manager_idField;
            }
            set
            {
                this.manager_idField = value;
            }
        }

        /// <remarks/>
        public string nickname
        {
            get
            {
                return this.nicknameField;
            }
            set
            {
                this.nicknameField = value;
            }
        }

        /// <remarks/>
        public string guid
        {
            get
            {
                return this.guidField;
            }
            set
            {
                this.guidField = value;
            }
        }

        /// <remarks/>
        public byte is_current_login
        {
            get
            {
                return this.is_current_loginField;
            }
            set
            {
                this.is_current_loginField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Roster
    {

        private string coverage_typeField;

        private byte weekField;

        private Players playersField;

        /// <remarks/>
        public string coverage_type
        {
            get
            {
                return this.coverage_typeField;
            }
            set
            {
                this.coverage_typeField = value;
            }
        }

        /// <remarks/>
        public byte week
        {
            get
            {
                return this.weekField;
            }
            set
            {
                this.weekField = value;
            }
        }

        /// <remarks/>
        public Players players
        {
            get
            {
                return this.playersField;
            }
            set
            {
                this.playersField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Players
    {

        private Player[] playerField;

        private byte countField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("player")]
        public Player[] player
        {
            get
            {
                return this.playerField;
            }
            set
            {
                this.playerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Player
    {
  
        private string player_keyField;

        private uint player_idField;

        private Name nameField;

        private string statusField;

        private string editorial_player_keyField;

        private string editorial_team_keyField;

        private string editorial_team_full_nameField;

        private string editorial_team_abbrField;

        private Bye_weeks bye_weeksField;

        private string uniform_numberField;

        private string display_positionField;

        private Headshot headshotField;

        private string image_urlField;

        private byte is_undroppableField;

        private string position_typeField;

        private string[] eligible_positionsField;

        private byte has_player_notesField;

        private bool has_player_notesFieldSpecified;

        private Selected_position selected_positionField;

        private Player_stats player_statsField;

        private Player_points player_pointsField;

        /// <remarks/>
        public string player_key
        {
            get
            {
                return this.player_keyField;
            }
            set
            {
                this.player_keyField = value;
            }
        }

        /// <remarks/>
        public uint player_id
        {
            get
            {
                return this.player_idField;
            }
            set
            {
                this.player_idField = value;
            }
        }

        /// <remarks/>
        public Name name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public string editorial_player_key
        {
            get
            {
                return this.editorial_player_keyField;
            }
            set
            {
                this.editorial_player_keyField = value;
            }
        }

        /// <remarks/>
        public string editorial_team_key
        {
            get
            {
                return this.editorial_team_keyField;
            }
            set
            {
                this.editorial_team_keyField = value;
            }
        }

        /// <remarks/>
        public string editorial_team_full_name
        {
            get
            {
                return this.editorial_team_full_nameField;
            }
            set
            {
                this.editorial_team_full_nameField = value;
            }
        }

        /// <remarks/>
        public string editorial_team_abbr
        {
            get
            {
                return this.editorial_team_abbrField;
            }
            set
            {
                this.editorial_team_abbrField = value;
            }
        }

        /// <remarks/>
        public Bye_weeks bye_weeks
        {
            get
            {
                return this.bye_weeksField;
            }
            set
            {
                this.bye_weeksField = value;
            }
        }

        /// <remarks/>
        public string uniform_number
        {
            get
            {
                return this.uniform_numberField;
            }
            set
            {
                this.uniform_numberField = value;
            }
        }

        /// <remarks/>
        public string display_position
        {
            get
            {
                return this.display_positionField;
            }
            set
            {
                this.display_positionField = value;
            }
        }

        /// <remarks/>
        public Headshot headshot
        {
            get
            {
                return this.headshotField;
            }
            set
            {
                this.headshotField = value;
            }
        }

        /// <remarks/>
        public string image_url
        {
            get
            {
                string _largeImage = this.image_urlField;

                if (this.image_urlField !=null && _largeImage.IndexOf("--/http")>0)
                {
                    _largeImage = _largeImage.Substring(_largeImage.IndexOf("--/http")+3);
                }
                
                return _largeImage;
            }
            set
            {
                this.image_urlField = value;
            }
        }

        /// <remarks/>
        public byte is_undroppable
        {
            get
            {
                return this.is_undroppableField;
            }
            set
            {
                this.is_undroppableField = value;
            }
        }

        /// <remarks/>
        public string position_type
        {
            get
            {
                return this.position_typeField;
            }
            set
            {
                this.position_typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("position", IsNullable = false)]
        public string[] eligible_positions
        {
            get
            {
                return this.eligible_positionsField;
            }
            set
            {
                this.eligible_positionsField = value;
            }
        }

        /// <remarks/>
        public byte has_player_notes
        {
            get
            {
                return this.has_player_notesField;
            }
            set
            {
                this.has_player_notesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool has_player_notesSpecified
        {
            get
            {
                return this.has_player_notesFieldSpecified;
            }
            set
            {
                this.has_player_notesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public Selected_position selected_position
        {
            get
            {
                return this.selected_positionField;
            }
            set
            {
                this.selected_positionField = value;
            }
        }

        /// <remarks/>
        public Player_stats player_stats
        {
            get
            {
                return this.player_statsField;
            }
            set
            {
                this.player_statsField = value;
                
            }
        }

        /// <remarks/>
        public Player_points player_points
        {
            get
            {
                return this.player_pointsField;
            }
            set
            {
                this.player_pointsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Name
    {

        private string fullField;

        private string firstField;

        private string lastField;

        private string ascii_firstField;

        private string ascii_lastField;

        /// <remarks/>
        public string full
        {
            get
            {
                return this.fullField;
            }
            set
            {
                this.fullField = value;
            }
        }

        /// <remarks/>
        public string first
        {
            get
            {
                return this.firstField;
            }
            set
            {
                this.firstField = value;
            }
        }

        /// <remarks/>
        public string last
        {
            get
            {
                return this.lastField;
            }
            set
            {
                this.lastField = value;
            }
        }

        /// <remarks/>
        public string ascii_first
        {
            get
            {
                return this.ascii_firstField;
            }
            set
            {
                this.ascii_firstField = value;
            }
        }

        /// <remarks/>
        public string ascii_last
        {
            get
            {
                return this.ascii_lastField;
            }
            set
            {
                this.ascii_lastField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Bye_weeks
    {

        private byte weekField;

        /// <remarks/>
        public byte week
        {
            get
            {
                return this.weekField;
            }
            set
            {
                this.weekField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Headshot
    {

        private string urlField;

        private string sizeField;

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Selected_position
    {

        private string coverage_typeField;

        private byte weekField;

        private string positionField;

        /// <remarks/>
        public string coverage_type
        {
            get
            {
                return this.coverage_typeField;
            }
            set
            {
                this.coverage_typeField = value;
            }
        }

        /// <remarks/>
        public byte week
        {
            get
            {
                return this.weekField;
            }
            set
            {
                this.weekField = value;
            }
        }

        /// <remarks/>
        public string position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Player_stats 
    {
        private string coverage_typeField;

        private byte weekField;

        private ObservableCollection<Stat> statsField;

        /// <remarks/>
        public string coverage_type
        {
            get
            {
                return this.coverage_typeField;
            }
            set
            {
                this.coverage_typeField = value;
            }
        }

        /// <remarks/>
        public byte week
        {
            get
            {
                return this.weekField;
            }
            set
            {
                this.weekField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("stat", IsNullable = false)]
        public ObservableCollection<Stat> stats
        {
            get
            {
                return this.statsField;
            }
            set
            {

                this.statsField = value;

                //RaisePropertyChanging("stats);
                //this.statsField = value;
                //RaisePropertyChanged("stats);

            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Stat
    {

        private string stat_idField;

        private decimal valueField;

        /// <remarks/>
        public string stat_id
        {
            get
            {
                return this.stat_idField;
            }
            set
            {
                this.stat_idField = value;
            }
        }

        /// <remarks/>
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class Player_points
    {

        private string coverage_typeField;

        private byte weekField;

        private decimal totalField;

        /// <remarks/>
        public string coverage_type
        {
            get
            {
                return this.coverage_typeField;
            }
            set
            {
                this.coverage_typeField = value;
            }
        }

        /// <remarks/>
        public byte week
        {
            get
            {
                return this.weekField;
            }
            set
            {
                this.weekField = value;
            }
        }

        /// <remarks/>
        public decimal total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }
    }


}






