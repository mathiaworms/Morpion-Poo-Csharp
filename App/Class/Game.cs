using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Class
{
    internal class Game
    {
        public List<Case> game_instance = new List<Case>();
        public List<Player> current_player= new List<Player>();
        public UI current_ui;
        public Game()
        {
            game_instance.Add(new Case("A1"));
            game_instance.Add(new Case("A2"));
            game_instance.Add(new Case("A3"));
            game_instance.Add(new Case("B1"));
            game_instance.Add(new Case("B2"));
            game_instance.Add(new Case("B3"));
            game_instance.Add(new Case("C1"));
            game_instance.Add(new Case("C2"));
            game_instance.Add(new Case("C3"));
            current_ui = new UI(this);
            current_player.Add(new Player(current_ui));
            current_player.Add(new Player(current_ui));
        }

        public void CatchCase(string _case_want_catch, Player _player)
        {
            foreach (Case case_instance in game_instance)
            {
                if (case_instance.position_name == _case_want_catch)
                {
                    Console.WriteLine(case_instance.position_name);
                    if (!case_instance.IsCatched())
                    {
                        case_instance.Catch(_player);
                    }
                    else
                    {
                        Console.WriteLine("this case is not playable, try again");
                        _player.ChooseCase(this);
                    }
                }
                
            }

        }
        public static void LaunchCoinForKnowWhoStart(Game this_instance)
        {
            UI.LaunchCoin();
            Random rnd = new Random();
            int coin = rnd.Next(1, 3);
            UI.ResultCoinWhoStart(coin, this_instance.current_player);
            if (coin == 1)
            {
                this_instance.current_player.Reverse();
            }

        }
        public static void InGameInstance(Game this_instance)
        {
            this_instance.current_ui.RefreshUI(this_instance);
            UI.PrintBoard(this_instance.current_ui);
            while (!this_instance.AllCaseIsCatched())
            {
                this_instance.current_player[0].ChooseCase(this_instance);
                if (this_instance.PaternOfWin())
                {
                    this_instance.WinnerIs(this_instance.current_player[0]);
                    break;
                }
                this_instance.current_player.Reverse();
            }
            if (this_instance.AllCaseIsCatched())
            {
                this_instance.Draw();
            }
            
        }
        public bool AllCaseIsCatched()
        {
            foreach (var _case_instance in this.game_instance)
            {
                if (!_case_instance.IsCatched())
                {
                    return false;

                }
            }
            return true;
        }
        public bool PaternOfWin()
        {
            var case_check = this.game_instance;
            if ( //ne pas oubliez team default 
                 (case_check[0].WhoHaveThisCase() == case_check[1].WhoHaveThisCase() && case_check[1].WhoHaveThisCase() == case_check[2].WhoHaveThisCase()
                 && case_check[0].Player_Catched != null && case_check[2].Player_Catched != null && case_check[3].Player_Catched != null)
                || (case_check[3].WhoHaveThisCase() == case_check[4].WhoHaveThisCase() && case_check[4].WhoHaveThisCase() == case_check[5].WhoHaveThisCase()
                && case_check[3].Player_Catched != null && case_check[4].Player_Catched != null && case_check[5].Player_Catched != null)
                || (case_check[6].WhoHaveThisCase() == case_check[7].WhoHaveThisCase() && case_check[7].WhoHaveThisCase() == case_check[8].WhoHaveThisCase()
                && case_check[6].Player_Catched != null && case_check[7].Player_Catched != null && case_check[8].Player_Catched != null)
                || (case_check[0].WhoHaveThisCase() == case_check[3].WhoHaveThisCase() && case_check[3].WhoHaveThisCase() == case_check[6].WhoHaveThisCase()
                && case_check[0].Player_Catched != null && case_check[3].Player_Catched != null && case_check[6].Player_Catched != null)
                || (case_check[1].WhoHaveThisCase() == case_check[4].WhoHaveThisCase() && case_check[4].WhoHaveThisCase() == case_check[7].WhoHaveThisCase()
                && case_check[1].Player_Catched != null && case_check[4].Player_Catched != null && case_check[7].Player_Catched != null)
                || (case_check[2].WhoHaveThisCase() == case_check[5].WhoHaveThisCase() && case_check[5].WhoHaveThisCase() == case_check[8].WhoHaveThisCase()
                && case_check[2].Player_Catched != null && case_check[5].Player_Catched != null && case_check[8].Player_Catched != null)
                || (case_check[0].WhoHaveThisCase() == case_check[4].WhoHaveThisCase() && case_check[4].WhoHaveThisCase() == case_check[8].WhoHaveThisCase()
                && case_check[0].Player_Catched != null && case_check[4].Player_Catched != null && case_check[8].Player_Catched != null)
                || (case_check[6].WhoHaveThisCase() == case_check[4].WhoHaveThisCase() && case_check[4].WhoHaveThisCase() == case_check[2].WhoHaveThisCase()
                && case_check[6].Player_Catched != null && case_check[4].Player_Catched != null && case_check[2].Player_Catched != null)
                )
            {
                return true;
            }

            return false;
        }
        public void WinnerIs(Player _player)
        {
            UI.WhoIsWinnerUI(_player);
            this.current_ui.RefreshUI(this);
            UI.PrintBoard(this.current_ui);
        }
        public void Draw()
        {
            UI.DrawUI();
            this.current_ui.RefreshUI(this);
            UI.PrintBoard(this.current_ui);
        }
    }
}
