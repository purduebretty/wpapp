using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Model
{
    class Teams
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng", IsNullable = false)]
        public partial class fantasy_content
        {

            private fantasy_contentUsers usersField;

            private string langField;

            private string uriField;

            private string timeField;

            private string copyrightField;

            private byte refresh_rateField;

            /// <remarks/>
            public fantasy_contentUsers users
            {
                get
                {
                    return this.usersField;
                }
                set
                {
                    this.usersField = value;
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public partial class fantasy_contentUsers
        {

            private fantasy_contentUsersUser userField;

            private byte countField;

            /// <remarks/>
            public fantasy_contentUsersUser user
            {
                get
                {
                    return this.userField;
                }
                set
                {
                    this.userField = value;
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
        public partial class fantasy_contentUsersUser
        {

            private string guidField;

            private fantasy_contentUsersUserGames gamesField;

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
            public fantasy_contentUsersUserGames games
            {
                get
                {
                    return this.gamesField;
                }
                set
                {
                    this.gamesField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public partial class fantasy_contentUsersUserGames
        {

            private fantasy_contentUsersUserGamesGame[] gameField;

            private byte countField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("game")]
            public fantasy_contentUsersUserGamesGame[] game
            {
                get
                {
                    return this.gameField;
                }
                set
                {
                    this.gameField = value;
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
        public partial class fantasy_contentUsersUserGamesGame
        {

            private ushort game_keyField;

            private ushort game_idField;

            private string nameField;

            private string codeField;

            private string typeField;

            private string urlField;

            private ushort seasonField;

            private fantasy_contentUsersUserGamesGameTeams teamsField;

            /// <remarks/>
            public ushort game_key
            {
                get
                {
                    return this.game_keyField;
                }
                set
                {
                    this.game_keyField = value;
                }
            }

            /// <remarks/>
            public ushort game_id
            {
                get
                {
                    return this.game_idField;
                }
                set
                {
                    this.game_idField = value;
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

            /// <remarks/>
            public string code
            {
                get
                {
                    return this.codeField;
                }
                set
                {
                    this.codeField = value;
                }
            }

            /// <remarks/>
            public string type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
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
            public ushort season
            {
                get
                {
                    return this.seasonField;
                }
                set
                {
                    this.seasonField = value;
                }
            }

            /// <remarks/>
            public fantasy_contentUsersUserGamesGameTeams teams
            {
                get
                {
                    return this.teamsField;
                }
                set
                {
                    this.teamsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public partial class fantasy_contentUsersUserGamesGameTeams
        {

            private fantasy_contentUsersUserGamesGameTeamsTeam teamField;

            private byte countField;

            /// <remarks/>
            public fantasy_contentUsersUserGamesGameTeamsTeam team
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
        public partial class fantasy_contentUsersUserGamesGameTeamsTeam
        {

            private string team_keyField;

            private byte team_idField;

            private string nameField;

            private byte is_owned_by_current_loginField;

            private string urlField;

            private fantasy_contentUsersUserGamesGameTeamsTeamTeam_logos team_logosField;

            private string waiver_priorityField;

            private byte number_of_movesField;

            private byte number_of_tradesField;

            private fantasy_contentUsersUserGamesGameTeamsTeamRoster_adds roster_addsField;

            private byte clinched_playoffsField;

            private bool clinched_playoffsFieldSpecified;

            private fantasy_contentUsersUserGamesGameTeamsTeamManagers managersField;

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
            public fantasy_contentUsersUserGamesGameTeamsTeamTeam_logos team_logos
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
            public fantasy_contentUsersUserGamesGameTeamsTeamRoster_adds roster_adds
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
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool clinched_playoffsSpecified
            {
                get
                {
                    return this.clinched_playoffsFieldSpecified;
                }
                set
                {
                    this.clinched_playoffsFieldSpecified = value;
                }
            }

            /// <remarks/>
            public fantasy_contentUsersUserGamesGameTeamsTeamManagers managers
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
        public partial class fantasy_contentUsersUserGamesGameTeamsTeamTeam_logos
        {

            private fantasy_contentUsersUserGamesGameTeamsTeamTeam_logosTeam_logo team_logoField;

            /// <remarks/>
            public fantasy_contentUsersUserGamesGameTeamsTeamTeam_logosTeam_logo team_logo
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
        public partial class fantasy_contentUsersUserGamesGameTeamsTeamTeam_logosTeam_logo
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
        public partial class fantasy_contentUsersUserGamesGameTeamsTeamRoster_adds
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
        public partial class fantasy_contentUsersUserGamesGameTeamsTeamManagers
        {

            private fantasy_contentUsersUserGamesGameTeamsTeamManagersManager managerField;

            /// <remarks/>
            public fantasy_contentUsersUserGamesGameTeamsTeamManagersManager manager
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
        public partial class fantasy_contentUsersUserGamesGameTeamsTeamManagersManager
        {

            private byte manager_idField;

            private string nicknameField;

            private string guidField;

            private byte is_commissionerField;

            private bool is_commissionerFieldSpecified;

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
            public byte is_commissioner
            {
                get
                {
                    return this.is_commissionerField;
                }
                set
                {
                    this.is_commissionerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool is_commissionerSpecified
            {
                get
                {
                    return this.is_commissionerFieldSpecified;
                }
                set
                {
                    this.is_commissionerFieldSpecified = value;
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




    }
}
