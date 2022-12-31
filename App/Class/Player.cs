using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Class
{
    internal class Player
    {
        public string name;
        public char team;
        
        public Player(UI _current_ui)
        {
            //demander nom et team 
            
            UI.AskName(_current_ui);
            name = Console.ReadLine();
            UI.AskTeam(_current_ui);
            team = Console.ReadLine()[0];
            
        }

        public void ChooseCase(Game _this_instance)
        {

            UI.AskCase(this);
            _this_instance.current_ui.RefreshUI(_this_instance);
            UI.PrintBoard(_this_instance.current_ui);
            _this_instance.CatchCase(Console.ReadLine(),this);
        }


    }
}
