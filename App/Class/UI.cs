using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Class
{
    internal class UI
    {
        public List<string> ui_board = new List<string>();
        int i = 1;
        public UI(Game _game_instance)
        {
            ui_board.Add("|---|---|---|---|");
            ui_board.Add("|---|-1-|-2-|-3-|");
            ui_board.Add("|-A-|-"+ _game_instance.game_instance[0].UI_print_team + "-|-"+ _game_instance.game_instance[1].UI_print_team + "-|-"+ _game_instance.game_instance[2].UI_print_team + "-|");
            ui_board.Add("|-B-|-"+ _game_instance.game_instance[3].UI_print_team + "-|-"+ _game_instance.game_instance[4].UI_print_team + "-|-"+ _game_instance.game_instance[5].UI_print_team + "-|");
            ui_board.Add("|-C-|-"+ _game_instance.game_instance[6].UI_print_team + "-|-"+ _game_instance.game_instance[7].UI_print_team + "-|-"+ _game_instance.game_instance[8].UI_print_team + "-|");
            ui_board.Add("|---|---|---|---|");
        }
        public void RefreshUI(Game _game_instance)
        {
            this.ui_board.Clear();
            this.ui_board.Add("|---|---|---|---|");
            this.ui_board.Add("|---|-1-|-2-|-3-|");
            this.ui_board.Add("|-A-|-" + _game_instance.game_instance[0].UI_print_team + "-|-" + _game_instance.game_instance[1].UI_print_team + "-|-" + _game_instance.game_instance[2].UI_print_team + "-|");
            this.ui_board.Add("|-B-|-" + _game_instance.game_instance[3].UI_print_team + "-|-" + _game_instance.game_instance[4].UI_print_team + "-|-" + _game_instance.game_instance[5].UI_print_team + "-|");
            this.ui_board.Add("|-C-|-" + _game_instance.game_instance[6].UI_print_team + "-|-" + _game_instance.game_instance[7].UI_print_team + "-|-" + _game_instance.game_instance[8].UI_print_team + "-|");
            this.ui_board.Add("|---|---|---|---|");
        }
        public static void AskName(UI _current_ui)
        {
            Console.WriteLine("player " + _current_ui.i + " :-What is your name");
           
        }
        public static void AskTeam(UI _current_ui)
        {
            Console.WriteLine("player " + _current_ui.i + " :-What is your Team (\"choose your char\")");
            _current_ui.i += 1;
        }
        public static void LaunchCoin()
        {
            Console.WriteLine("Launch Coin for know who start");
        }
        public static void ResultCoinWhoStart(int _result_coin, List<Player> _list_player)
        {
            string whostart = (_result_coin == 1) ? ("It's Head, the player who start is : " + _list_player[0]) : ("It's tails, the player who start is :  " + _list_player[1]);
            Console.WriteLine(whostart);
        }
        public static void PrintBoard(UI _this_UI)
        {
            foreach (var _part in _this_UI.ui_board)
            {
                Console.WriteLine(_part);
            }
        }
        public static void AskCase(Player _player)
        {
            Console.WriteLine(" player : "+ _player.name +", Choose an empty case");
        }
        public static void WhoIsWinnerUI(Player _player)
        {
            Console.WriteLine("The WINNER IS : " + _player.name);
        }
        public static void DrawUI()
        {
            Console.WriteLine("DRAW ! No one has win :/ ");
        }
    }
}
