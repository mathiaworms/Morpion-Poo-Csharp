using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace App.Class
{
    internal class Case
    {
        public string position_name;
        public Player Player_Catched;
        public char UI_print_team;

        public Case(string position_name)
        {
            this.position_name = position_name;
            UI_print_team = ' ';
        }

        public bool IsCatched()
        {
            if (Player_Catched == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Player WhoHaveThisCase()
        {
            if (Player_Catched != null)
            {
                return Player_Catched;
            }
            return null;
        }

        public void Catch(Player _player)
        {
            Player_Catched = _player;
            UI_print_team = _player.team;
        }

    }
}
